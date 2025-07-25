using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,)
        {
            _logger = logger;
        }

        [HttpPost("createuser")]
        public async Task<ActionResult> CreateUser(long tgID, )
        {
            _logger.LogInformation($"POST запрос api/User/createuser \n id: {id}");
        }
    }
}
