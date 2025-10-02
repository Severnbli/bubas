using bubas.Source.TelegramBot.Forms;
using TelegramBotBase;
using TelegramBotBase.DependencyInjection;

namespace bubas.Source.Shared.Extensions;

public static class BotExtensions
{
    public static void AddDefaultCommands(this BotBase bot)
    {
        bot.BotCommand += async (sender, args) =>
        {
            switch (args.Command)
            {
                default:
                {
                    await args.Device.ActiveForm.NavigateTo<StartForm>();
                    break;
                }
            }
        };
    }
}