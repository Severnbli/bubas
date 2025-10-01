using bubas.Source.Core.Interfaces;

namespace bubas.Source.TelegramBot.Starters;

public class DefaultBotStarter(IBotBuilder builder) : IBotStarter
{
    public async Task StartBot()
    {
        var bot = builder.BuildBot();
        await bot.UploadBotCommands();
        await bot.Start();

        await Task.Delay(-1);
    }
}