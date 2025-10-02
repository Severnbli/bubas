using bubas.Source.TelegramBot.Forms;
using Telegram.Bot.Types;
using TelegramBotBase;
using TelegramBotBase.Builder.Interfaces;
using TelegramBotBase.Commands;
using TelegramBotBase.DependencyInjection;

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
}