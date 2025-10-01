using Autofac;
using bubas.Source.Core.Interfaces;
using bubas.Source.TelegramBot.Builders;
using bubas.Source.TelegramBot.Starters;

namespace bubas.Source.Bootstrap.Modules;

public class BotModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DefaultBotBuilder>().As<IBotBuilder>().SingleInstance();
        builder.RegisterType<DefaultBotStarter>().As<IBotStarter>().SingleInstance();
    }
}