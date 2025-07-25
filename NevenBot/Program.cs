using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using NevenBot.Keyboards;
using NevenBot.Utils;

namespace NevenBot
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string token = Config.GetToken();

            if (token != "Error: Token not found")
            {
                // Инициализация бота
                Host.Start(token);
                Console.ReadKey();
                
            }
            else
            {
                Console.WriteLine("Ошибка, отсутствует токен или appsettings.json");
            }

        }

    }
}
