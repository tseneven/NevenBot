using NevenBot.Handlers;
using NevenBot.Keyboards;
using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Host
{
    private static TelegramBotClient? _botClient;
    private static ReceiverOptions? _receiverOptions;

    
    // Метод бота
    static public Task Start(string token)
    {
        _botClient = new TelegramBotClient(token);
        _receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[]
            {
                UpdateType.Message,
                UpdateType.CallbackQuery,
            },
        };

        using var cts = new CancellationTokenSource();

        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

        Task.Delay(-1); // Бесконечная задержка

        var clearUsersStates = new NevenBot.Utils.ClearUsersStates();
        clearUsersStates.Start();

        return Task.CompletedTask;
    }

    // Метод обработки ошибок бота
    static private Task ErrorHandler(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

    // Метод обработки обновлений бота
    static private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                {
                        if (update.Message is { } msg)
                        {
                            await MessageHandler.HandleAsync(client, msg);
                        }
                        return;
                }
                case UpdateType.CallbackQuery:
                {
                        await CallbackHandler.HandleAsync(client, update.CallbackQuery!);
                        return;
                }
            }


            await Task.CompletedTask;
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.ToString());
        }
    }
}