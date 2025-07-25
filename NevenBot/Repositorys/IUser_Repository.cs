using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevenBot.Repositorys
{
    internal interface IUser_Repository
    {
        Task<string> Create (UserDTO userDTO);
    }
}
