using bubas.Source.Core.Interfaces;
using bubas.Source.Shared.Utils;
using bubas.Source.TelegramBot.Forms;
using TelegramBotBase;
using TelegramBotBase.Builder;

namespace bubas.Source.TelegramBot.Builders;

public class DefaultBotBuilder(IServiceProvider serviceProvider) : IBotBuilder
{
    public BotBase BuildBot()
    {
        var builder = BotBaseBuilder
            .Create()
            .WithAPIKey(BotUtils.GetBotApiKey())
            .DefaultMessageLoop()
            .WithServiceProvider<StartForm>(serviceProvider)
            .NoProxy()
            .NoCommands()
            .UseJSON()
            .UseRussian()
            .UseThreadPool();

        var bot = builder.Build();
        
        return bot;
    }
}