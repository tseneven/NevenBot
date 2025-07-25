using NevenBot.Dto;
using NevenBot.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevenBot.Utils
{
    internal class AddUserState
    {
        static public void Add(long id, string text)
        {
            var userState = MessageHandler.UserStates.GetOrAdd(id, new UserState());
            userState.State = text;
        }
    }
}
