using FuelMachine;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;



internal class Program
{
    private static TelegramBotClient botClient;
    private static int townCoeff;
    private static int fuelCoeff;
    private static int airCondCoeff;
    private static decimal modelConsumptionCoeff;
    private static decimal calculatedConsumption;

    private static async Task Main(string[] args)
    {
        using CancellationTokenSource cts = new();
        var send = new BotMessageSend();
        botClient = new TelegramBotClient(token);
        var remove = new ReplyKeyboardRemove();
        var me = await botClient.GetMeAsync();
        CalculateСonsumption cons = new CalculateСonsumption();

        ReplyKeyboardMarkup replyKeyboardHello = new(new[]
        {
            new KeyboardButton[] { "Начать подсчет", "Помощь" },
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };

        ReplyKeyboardMarkup replyKeyboardMarks = new(new[]
        {
            new KeyboardButton[] { "Вывести все марки"},
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };
       
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );
        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();
        cts.Cancel();

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await BotOnMessageReceived(botClient, update.Message!);
                    break;
                case UpdateType.CallbackQuery:
                    await OnAnswer(botClient, update.CallbackQuery!, update.CallbackQuery!.From.Id);
                    break;
                default:
                    await botClient.SendTextMessageAsync
                    (
                        chatId: update.Message!.Chat.Id,
                        text: "Такое неоперделено"
                    );
                    break;
            }
        }
        async Task BotOnMessageReceived(ITelegramBotClient bot, Message message)
        {
            if (message.Type != MessageType.Text)
            {
                await botClient.SendTextMessageAsync
                (
                    chatId: message.Chat.Id,
                    text: "Такое неоперделено"
                );

                return;
            }
            var user = message.From;
            var chatId = message.Chat.Id;
            var marksButtons = new ButtonsCreate().ButtonCarsMarkCreate();
            Console.WriteLine($"Receive message type: {message.Type}");
            Console.WriteLine($"Received a '{message.Text}' message in chat {chatId} from @{user!.Username}");
            
            var action = message.Text!;
            switch (action)
            {
                case "/start":
                    send.SendMessageReply(botClient, chatId, replyKeyboardHello, "Привет, это помощник в подсчете расхода топлива.");
                    break;
                case "Начать подсчет":
                    send.SendMessageReply(botClient, chatId, replyKeyboardMarks, "Вы начали подсчет расхода топлива.");
                    break;
                case "Вывести все марки":
                    send.SendMessageInline(botClient, chatId, marksButtons, "Список марок авто");
                    break;
                case "Помощь":
                    send.SendMessageReply(botClient, chatId, replyKeyboardHello, "Небходимо ввести марку, модель автомобиля \n" +
                              "наличие кондиционера, город");
                    break;

                default:
                    int number;
                    calculatedConsumption = 0;
                    bool success = int.TryParse(message.Text, out number);

                    if (success)
                        calculatedConsumption = cons.Calculate(townCoeff, airCondCoeff, fuelCoeff, modelConsumptionCoeff, number);
                    send.SendMessageReply(botClient, chatId, replyKeyboardHello, "Рассчитанный расход топлива " + calculatedConsumption);
                    break;
            }
        }

        async Task OnAnswer(ITelegramBotClient bot, CallbackQuery callbackQuery, long userId)
        {
            var user = callbackQuery.From;
            var c = new GetCoefficients();
            var towns = new ButtonsCreate().ButtonTownsCreate();
            var modelsConditioner = new ButtonsCreate().ButtonAirConditionCreate();
            var modelsFuel = new ButtonsCreate().ButtonFuelCreate();
            Console.WriteLine($"{user.FirstName} ({user.Id}) нажал на кнопку: {callbackQuery.Data}");
            var chat = callbackQuery.Message.Chat;
            switch (callbackQuery.Data)
            {
                case "1":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "2":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "3":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "4":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "5":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "6":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        var modelsButtons = new ButtonsCreate().ButtonModelsCreate(callbackQuery);
                        send.SendMessageInline(botClient, chat.Id, modelsButtons, $"Выберите модель марки {callbackQuery.Message.Text}");
                        return;
                    }
                case "Octavia":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsFuel, $"Выберите дополнительный вид топлива ");
                        modelConsumptionCoeff = c.GetModelConsumption("Octavia");
                        return;
                    }
                case "Rapid":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsFuel, $"Выберите наличие кондиционера ");
                        modelConsumptionCoeff = c.GetModelConsumption("Rapid");
                        return;
                    }
                case "Пропан":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsConditioner, $"Выберите наличие кондиционера ");
                        fuelCoeff = c.GetFuelCoefficient("Пропан");
                        return;
                    }
                case "Метан":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsConditioner, $"Выберите наличие кондиционера ");
                        fuelCoeff = c.GetFuelCoefficient("Метан");
                        return;
                    }
                case "Дизель":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsConditioner, $"Выберите наличие кондиционера ");
                        fuelCoeff = c.GetFuelCoefficient("Дизель");
                        return;
                    }
                case "Бензин":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, modelsConditioner, $"Выберите наличие кондиционера ");
                        fuelCoeff = c.GetFuelCoefficient("Бензин");
                        return;
                    }

                case "True":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, towns, $"Выберите город ");
                        airCondCoeff = c.GetAirCoefficient("True");
                        return;
                    }
                case "False":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessageInline(botClient, chat.Id, towns, $"Выберите город ");
                        airCondCoeff = c.GetAirCoefficient("True");
                        return;
                    }
                case "БРЕСТ":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessage(botClient, chat.Id, $"Введите пробег за сутки: ");
                        townCoeff = c.GetTownCoefficient("БРЕСТ");
                        return;
                    }
                case "МИНСК":
                    {
                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                        send.SendMessage(botClient, chat.Id, $"Введите пробег за сутки: ");
                        townCoeff = c.GetTownCoefficient("МИНСК");
                        return;
                    }
            }
        return;
    }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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


        Console.ReadKey();

    }
}