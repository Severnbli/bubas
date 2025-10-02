using Autofac;
using bubas.Source.Bootstrap.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Installers;

public class DefaultDiInstaller : BaseDiInstaller
{
    protected override void RegisterModules(ContainerBuilder builder, IServiceCollection services)
    {
        builder.RegisterModule<DbModule>();
        builder.RegisterModule<BotModule>();
        builder.RegisterModule<ServicesModule>();
    }
}