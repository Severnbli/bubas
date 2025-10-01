using bubas.Source.Core.Interfaces;
using bubas.Source.Shared.Utils;
using bubas.Source.TelegramBot.Forms;
using TelegramBotBase;
using TelegramBotBase.Builder;

namespace bubas.Source.TelegramBot.Builders;

public class DefaultBotBuilder : IBotBuilder
{
    public BotBase BuildBot()
    {
        var builder = BotBaseBuilder
            .Create()
            .WithAPIKey(BotUtils.GetBotApiKey())
            .DefaultMessageLoop()
            .WithStartForm<StartForm>()
            .NoProxy()
            .NoCommands()
            .UseJSON()
            .UseRussian()
            .UseThreadPool();

        var bot = builder.Build();
        
        return bot;
    }
}