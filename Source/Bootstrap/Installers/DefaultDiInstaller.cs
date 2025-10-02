using bubas.Source.Bootstrap.Modules;
using bubas.Source.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Installers;

public class DefaultDiInstaller : BaseDiInstaller
{
    protected override void RegisterDependencies(IServiceCollection serviceCollection)
    {
        serviceCollection.RegisterModule<DbModule>();
        serviceCollection.RegisterModule<BotModule>();
        serviceCollection.RegisterModule<ServicesModule>();
    }
}