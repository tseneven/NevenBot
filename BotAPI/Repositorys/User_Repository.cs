using DTO;
using Microsoft.Data.SqlClient;

namespace BotAPI.Repositorys
{
    public class User_Repository:IUser_Repository
    {
        string? connect;

        public User_Repository(IConfiguration configuration)
        {
            connect = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<string> CreateAsync(UserDTO userDTO)
        {
            using (SqlConnection )
        }
    }
}
