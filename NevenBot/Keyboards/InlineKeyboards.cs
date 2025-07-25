using System.Security.Cryptography;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace NevenBot.Keyboards
{
    internal class InlineKeyboards
    {
        public static async Task MenuInlineKeyboard(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Траты💰", "spending"),
                    InlineKeyboardButton.WithCallbackData("Список задач👨‍💻", "list_of_tasks"),
                    InlineKeyboardButton.WithCallbackData("Напоминания🕛", "reminders"),

                },
            });

            await botClient.SendMessage(
                chatId: chatId,
                text: "Добро пожаловать! Выберите действие:",
                replyMarkup: inlineKeyboard
            );
        }

        public static async Task SpendingInlineKeyboard(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Показать список🗒", "show_spending"),
                    InlineKeyboardButton.WithCallbackData("Добавить трату➕", "add_spending"),
                    InlineKeyboardButton.WithCallbackData("Удалить трату➖", "delete_spending"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Назад🔙", "back"),
                }
            });

            await botClient.SendMessage(
                chatId: chatId,
                text: "Выберите действие" ,
                replyMarkup: inlineKeyboard
            );
        }


        public static async Task List_Of_TasksInlineKeyboard(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Показать список🗒", "show_list_of_task"),
                    InlineKeyboardButton.WithCallbackData("Добавить задачу➕", "add_task"),
                    InlineKeyboardButton.WithCallbackData("Удалить задачу➖", "delete_task"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Назад🔙", "back"),
                }
            });

            await botClient.SendMessage(
                chatId: chatId,
                text: "Выберите действие",
                replyMarkup: inlineKeyboard
            );
        }


        public static async Task RemindersInlineKeyboard(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Показать список🗒", "show_reminders"),
                    InlineKeyboardButton.WithCallbackData("Добавить напоминание➕", "add_reminder"),
                    InlineKeyboardButton.WithCallbackData("Удалить напоминаниe➖", "delete_reminder"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Назад🔙", "back"),
                }
            });

            await botClient.SendMessage(
                chatId: chatId,
                text: "Выберите действие",
                replyMarkup: inlineKeyboard
            );
        }

    }
}
