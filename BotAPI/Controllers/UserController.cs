using BotAPI.Repositorys;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogger<UserController> _logger;
        IUser_Repository _Repository;

        public UserController(ILogger<UserController> logger, User_Repository Repository)
        {
            _logger = logger;
            _Repository = Repository;
        }

        [HttpPost("createuser")]
        public async Task<ActionResult> CreateUser([FromBody]UserDTO userDTO)
        {
            userDTO.atCreated = DateTime.Now;

            _logger.LogInformation($"POST запрос api/User/createuser \n id: {userDTO.tgid}");

            try
            {
                var result = await _Repository.CreateAsync(userDTO);
                return result switch
                {
                    "200" => Ok(),
                    "409" => StatusCode(409),
                    _ => StatusCode(400),
                };
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
