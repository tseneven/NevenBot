using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

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
                Host.OnMessage += OnMessage;
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine(@"Ошибка, отсутствует токен или appsettings.json в папке \bin\Debug\net8.0\");
            }

        }

        // Метод действия бота на сообщение пользователя. Сюда основной функционал и вызов методов API и работы с DB
        private static async void OnMessage(ITelegramBotClient client, Update update)
        {
            await client.SendMessage(update.Message?.Chat.Id ?? 8152895676, "Текст");
        }

        // Метод получения токена из appsettings.json
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
