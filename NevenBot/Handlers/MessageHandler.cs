using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using NevenBot.Keyboards;
using System.Collections.Concurrent;
using NevenBot.Dto;
using System.ComponentModel;

namespace NevenBot.Handlers
{
    internal class MessageHandler
    {
        public static ConcurrentDictionary<long, UserState> UserStates = new();

        public static async Task HandleAsync(ITelegramBotClient botClient, Message message) 
        {
            if (message.Text == null)
                return;

            long chatId = message.Chat.Id;

            if (message.Text.ToLower()[0] == '/')
            {
                switch (message.Text.ToLower())
                {
                    case "/start":
                        await InlineKeyboards.MenuInlineKeyboard(botClient, chatId);
                        break;

                    case "/help":
                        await botClient.SendMessage(chatId, "📖 Список команд:\n/start - меню\n/help - помощь\n/back - вернуться");
                        break;
                    case "/back":
                        await InlineKeyboards.MenuInlineKeyboard(botClient, chatId);
                        UserStates.TryRemove(chatId, out _);
                        break;

                    default:
                        await botClient.SendMessage(chatId, "🤖 Неизвестная команда. Напиши /help");
                        break;
                }

            }
            else
            {

            }

        }

    }
}
