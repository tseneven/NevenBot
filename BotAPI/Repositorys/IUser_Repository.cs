using DTO;

namespace BotAPI.Repositorys
{
    public interface IUser_Repository
    {
        Task<string> CreateAsync(UserDTO userDTO);
    }
}
