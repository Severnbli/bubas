using TelegramBotBase;

namespace bubas.Source.Core.Interfaces;

public interface IBotStarter
{
    public Task<BotBase> StartBot();
}