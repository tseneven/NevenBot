using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using NevenBot.Keyboards;
using NevenBot.Utils;

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

            int DebugID = Config.GetDebugID();

            switch (data)
            {
                // Метод перехода в раздел Траты
                case "spending":
                    await InlineKeyboards.SpendingInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод перехода в раздел Список задач
                case "list_of_tasks":
                    await InlineKeyboards.List_Of_TasksInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID , messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод перехода в раздел Напоминания
                case "reminders":
                    await InlineKeyboards.RemindersInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод выхода в меню
                case "back":
                    await InlineKeyboards.MenuInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод добавления траты
                case "add_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "show_spending!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод удаления траты
                case "delete_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод показа списка трат
                case "show_spending":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод показа списка задач
                case "show_list_of_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод добавления задачи
                case "add_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод удаления задачи
                case "delete_task":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод показа списка напоминаний
                case "show_reminders":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод добавления напоминания
                case "add_reminder":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Метод удаления напоминания
                case "delete_reminder":
                    await botClient.AnswerCallbackQuery(callback.Id, "Пока!");
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    break;

                // Защита каллбеков
                default:
                    await botClient.AnswerCallbackQuery(callback.Id, "Неизвестная команда");
                    break;
            }
        }
    }
}
