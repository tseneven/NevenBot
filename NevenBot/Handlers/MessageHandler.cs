using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using NevenBot.Keyboards;

namespace NevenBot.Handlers
{
    internal class MessageHandler
    {
        public static async Task HandleAsync(ITelegramBotClient botClient, Message message) 
        {
            if (message.Text == null)
                return;

            long chatId = message.Chat.Id;

            switch (message.Text.ToLower())
            {
                case "/start":
                    await InlineKeyboards.MenuInlineKeyboard(botClient, chatId);
                    break;

                case "/help":
                    await botClient.SendMessage(chatId, "📖 Список команд:\n/start - меню\n/help - помощь");
                    break;

                default:
                    await botClient.SendMessage(chatId, "🤖 Неизвестная команда. Напиши /help");
                    break;
            }
        }

    }
}
