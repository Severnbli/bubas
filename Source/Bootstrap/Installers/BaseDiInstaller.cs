using bubas.Source.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Installers;

public abstract class BaseDiInstaller : IDiInstaller
{
    public IServiceProvider InstallDiContainer()
    {
        var serviceCollection = new ServiceCollection();
        
        RegisterDependencies(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider(); 
        return serviceProvider;
    }
    
    protected abstract void RegisterDependencies(IServiceCollection serviceCollection);
}