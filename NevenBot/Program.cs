using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using NevenBot.Keyboards;

namespace NevenBot
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string token = GetToken();

            if (token != "Error: Token not found")
            {
                // Инициализация бота
                Host.Start(token);
                Host.OnMessage += OnMessageStart;
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Ошибка, отсутствует токен или appsettings.json");
            }

        }

        // Метод действия бота на сообщение пользователя
        private static async void OnMessageStart(ITelegramBotClient client, Update update)
        {

        }

        static private string GetToken()
        {
            try
            {
                var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfiguration config = builder.Build();

                string token = config["ApiToken"];

                return token;

            }
            catch
            {
                return "Error: Token not found";

            }
        }
    }
}
