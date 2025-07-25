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
    }
}
