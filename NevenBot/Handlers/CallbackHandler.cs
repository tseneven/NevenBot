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

    // Обработчик Callback действий
    internal class CallbackHandler
    {
        public static async Task HandleAsync(ITelegramBotClient botClient, CallbackQuery callback)
        {
            string? data = callback.Data;

            if (data == null)
                return;

            switch (data)
            {
                case "spending":
                    await InlineKeyboards.SpendingInlineKeyboard(botClient, callback.Message?.Chat.Id ?? 0);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "list_of_tasks":
                    await InlineKeyboards.List_Of_TasksInlineKeyboard(botClient, callback.Message?.Chat.Id ?? 0);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "reminders":
                    await InlineKeyboards.RemindersInlineKeyboard(botClient, callback.Message?.Chat.Id ?? 0);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "back":
                    await InlineKeyboards.MenuInlineKeyboard(botClient, callback.Message?.Chat.Id ?? 0);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "add_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "show_spending!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "delete_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "show_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;
                case "show_list_of_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "add_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "delete_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "show_reminders":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "add_reminder":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;

                case "delete_reminder":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id, messageId: callback.Message.Id);
                    break;


                default:
                    await botClient.AnswerCallbackQuery(callback.Id, "Неизвестная команда");
                    break;
            }
        }
    }
}
