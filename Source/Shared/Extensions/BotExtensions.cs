using bubas.Source.TelegramBot.Forms;
using TelegramBotBase;
using TelegramBotBase.Base;
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
                case "/main_menu":
                {
                    await args.Device.ActiveForm.NavigateTo<MainMenuForm>();
                    break;
                }
                case "/start":
                {
                    await args.Device.ActiveForm.NavigateTo<StartForm>();
                    break;
                }
                case "/help":
                {
                    await args.Device.Send("Тут мусіла б быць нейкая мудрая думка, але замест яе — гэты тэкст.");
                    break;
                }
                default:
                {
                    await args.Device.Send("Хм, не ведаю такой каманды. Паспрабуй выкарыстаць /help 😉");
                    break;
                }
            }
        };
    }

    public static void AddDefaultCommandsProviders(this List<BotCommandScopeGroup> commandScopeGroups)
    {
        commandScopeGroups.Start("Паздароўкацца з ботам");
        commandScopeGroups.Help("Адкрыць лістоўку-нагадку");
        commandScopeGroups.Add("main_menu", "Адкрыць галоўнае меню");
    }

    public static async Task<CallbackData?> GetCallbackData(this MessageResult message)
    {
        var call = message.GetData<CallbackData>();
        await message.ConfirmAction();
        return call;
    }

    public static async Task ProcessCallbackData(this MessageResult message, Dictionary<string, Func<Task>> cases)
    {
        var call = await message.GetCallbackData();
        if (call == null) return;

        message.Handled = true;

        if (!cases.TryGetValue(call.Value, out var action))
        {
            message.Handled = false;
            return;
        }
        
        await action();
    }
}