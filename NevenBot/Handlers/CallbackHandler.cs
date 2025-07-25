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

            long DebugID = Config.GetDebugID();

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
                    Add(callback.Message?.Chat.Id, "add_spending", "spending");
                    break;

                // Метод удаления траты
                case "delete_spending":
                    Add(callback.Message?.Chat.Id, "delete_spending", "spending");
                    break;

                // Метод показа списка трат
                case "show_spending":
                    Add(callback.Message?.Chat.Id, "show_spending", "spending");
                    break;

                // Метод показа списка задач
                case "show_list_of_task":
                    Add(callback.Message?.Chat.Id, "show_list_of_task", "list_of_task");
                    break;

                // Метод добавления задачи
                case "add_task":
                    Add(callback.Message?.Chat.Id, "add_task", "list_of_task");
                    break;

                // Метод удаления задачи
                case "delete_task":
                    Add(callback.Message?.Chat.Id, "delete_task", "list_of_task");
                    break;

                // Метод показа списка напоминаний
                case "show_reminders":
                    Add(callback.Message?.Chat.Id, "show_reminder", "reminder");
                    break;

                // Метод добавления напоминания
                case "add_reminder":
                    Add(callback.Message?.Chat.Id, "add_reminder", "reminder");
                    break;

                // Метод удаления напоминания
                case "delete_reminder":
                    Add(callback.Message?.Chat.Id, "delete_reminder", "reminder");
                    break;
                   
                // Метод выхода в раздел трат
                case "back|spending":
                    await InlineKeyboards.SpendingInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    MessageHandler.UserStates.TryRemove(callback.Message?.Chat.Id ?? DebugID, out _);
                    break;

                // Метод выхода в раздел списка задач
                case "back|list_of_task":
                    await InlineKeyboards.List_Of_TasksInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    MessageHandler.UserStates.TryRemove(callback.Message?.Chat.Id ?? DebugID, out _);
                    break;

                // Метод выхода в напоминаний
                case "back|reminder":
                    await InlineKeyboards.RemindersInlineKeyboard(botClient, callback.Message?.Chat.Id ?? DebugID);
                    await botClient.DeleteMessage(callback.Message?.Chat.Id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                    MessageHandler.UserStates.TryRemove(callback.Message?.Chat.Id ?? DebugID, out _);
                    break;


                // Защита каллбеков
                default:
                    await botClient.AnswerCallbackQuery(callback.Id, "Неизвестная команда");
                    break;
            }

            async void Add(long? id, string text, string start)
            {
                await botClient.DeleteMessage(id ?? DebugID, messageId: callback.Message?.Id ?? 0);
                AddUserState.Add(id ?? DebugID, text);
                Logger.LoggerInConsole(id ?? DebugID, text);
                await InlineKeyboards.EditInlineKeyboard(botClient, id ?? DebugID, "Введите название", start);
            }
        }
    }
}
