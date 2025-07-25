using NevenBot.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevenBot.Utils
{
    internal class Logger
    {
        static public void LoggerInConsole(long id, string text)
        {
            Console.WriteLine($"ID: {id}, совершил действие: {text}");
        }
        static public void TimerStart()
        {
            Console.WriteLine("Таймер запущен");
        }

        static public void TimerEnd()
        {
            Console.WriteLine("Очистка состояний пользователей...");
            Console.WriteLine($"Очищено {MessageHandler.UserStates.Count} состояний!");
        }
    }
}
