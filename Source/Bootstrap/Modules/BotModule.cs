using bubas.Source.Core.Interfaces;
using bubas.Source.TelegramBot.Builders;
using bubas.Source.TelegramBot.Starters;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Modules;

public class BotModule : IDiModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IBotBuilder, DefaultBotBuilder>();
        serviceCollection.AddSingleton<IBotStarter, DefaultBotStarter>();
    }
}