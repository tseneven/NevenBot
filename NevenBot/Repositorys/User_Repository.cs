using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NevenBot.Repositorys
{
    internal class User_Repository: IUser_Repository
    {
        HttpClient _HttpClient = new HttpClient();

        public async Task<string> Create(UserDTO userDTO)
        {
            try
            {
               var response = await _HttpClient.PostAsJsonAsync("http://localhost:8008/api/User/createuser", userDTO);

                Console.WriteLine($"Запрос завершился кодом: {response.StatusCode.ToString()} у ID: {userDTO.tgid}");
                return await response.Content.ReadAsStringAsync();

            }
            catch 
            {
                Console.WriteLine($"WARN, 500 Ошибка у ID: {userDTO.tgid}");
                return "500";
            }
        }
    }
}
