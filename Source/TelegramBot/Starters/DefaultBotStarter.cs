using bubas.Source.Core.Interfaces;
using TelegramBotBase;

namespace bubas.Source.TelegramBot.Starters;

public class DefaultBotStarter(IBotBuilder builder) : IBotStarter
{
    public async Task<BotBase> StartBot()
    {
        var bot = builder.BuildBot();
        await bot.UploadBotCommands();
        await bot.Start();
        
        return bot;
    }
}