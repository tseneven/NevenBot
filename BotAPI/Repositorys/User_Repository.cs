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

        public async Task<string> CreateAsync(UserDTO userDTO)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                await conn.OpenAsync();


                // Проверка: есть ли такой логин
                string checkQuery = "SELECT COUNT(*) FROM dbo.Users WHERE TGID = @tgid";
                using var checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@tgid", userDTO.tgid);

                int count = (int)await checkCmd.ExecuteScalarAsync();

                if (count > 0)
                    return "409"; // пользователь уже есть

                // Вставка нового пользователя
                string insertQuery = "INSERT INTO dbo.Users (TGID, Username, DisplayName, isActive, atCreated) VALUES (@tgid, @username, @displayname, @isactive, @atcreated)";
                using var insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@tgid", userDTO.tgid);
                insertCmd.Parameters.AddWithValue("@username", userDTO.username);
                insertCmd.Parameters.AddWithValue("@displayname", userDTO.displayname);
                insertCmd.Parameters.AddWithValue("@isactive", userDTO.isActive);
                insertCmd.Parameters.AddWithValue("@atcreated", userDTO.atCreated);

                int rows = await insertCmd.ExecuteNonQueryAsync();

                return rows > 0 ? "200" : "400";
            }
        }
    }
}
