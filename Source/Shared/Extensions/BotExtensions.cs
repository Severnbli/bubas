using bubas.Source.TelegramBot.Forms;
using Telegram.Bot.Types;
using TelegramBotBase;
using TelegramBotBase.Base;
using TelegramBotBase.Builder.Interfaces;
using TelegramBotBase.Commands;
using TelegramBotBase.DependencyInjection;
using TelegramBotBase.Form;

namespace bubas.Source.Shared.Extensions;

public static class BotExtensions
{
    public static void AddDefaultCommandsHandler(this BotBase bot)
    {
        bot.BotCommand += async (sender, args) =>
        {
            switch (args.Command)
            {
                case "main_menu":
                {
                    await args.Device.ActiveForm.NavigateTo<MainMenuForm>();
                    break;
                }
                default:
                {
                    await args.Device.ActiveForm.NavigateTo<StartForm>();
                    break;
                }
            }
        };
    }

    public static void AddDefaultCommandsProviders(this List<BotCommandScopeGroup> commandScopeGroups)
    {
        commandScopeGroups.Start("Паздароўкацца з ботам");
        commandScopeGroups.Add("main_menu", "Адкрыць галоўнае меню");
    }

    public static async Task<CallbackData?> GetCallbackData(this MessageResult message)
    {
        var call = message.GetData<CallbackData>();
        await message.ConfirmAction();
        return call;
    }
}