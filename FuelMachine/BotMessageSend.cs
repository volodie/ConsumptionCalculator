﻿using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace FuelMachine
{
    static class BotMessageSend
    {
        async public static void SendMessageReply(TelegramBotClient botclient, long idChat, ReplyKeyboardMarkup keyboard, string textMessage) 
        {
            await botclient.SendTextMessageAsync
                    (
                        chatId: idChat,
                        text: textMessage,
                        replyMarkup: keyboard
                    );
        }
        async public static void SendMessageInline(TelegramBotClient botclient, long idChat, InlineKeyboardMarkup keyboard, string textMessage)
        {
            await botclient.SendTextMessageAsync
                    (
                        chatId: idChat,
                        text: textMessage,
                        replyMarkup: keyboard
                    );
        }
        async public static void SendMessage(TelegramBotClient botclient, long idChat,  string textMessage)
        {
            await botclient.SendTextMessageAsync
                    (
                        chatId: idChat,
                        text: textMessage
                    );
        }
    }
}
