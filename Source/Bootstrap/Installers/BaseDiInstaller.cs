using Autofac;
using bubas.Source.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Installers;

public abstract class BaseDiInstaller : IDiInstaller
{
    public IContainer InstallDiContainer()
    {
        var builder = new ContainerBuilder();
        
        RegisterDependencies(builder);
        
        var container = builder.Build(); 
        return container;
    }

    protected virtual void RegisterDependencies(ContainerBuilder builder)
    {
        var serviceCollection = new ServiceCollection();
        
        RegisterModules(builder, serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        builder.RegisterInstance(serviceProvider).As<IServiceProvider>().SingleInstance();
    }
    
    protected abstract void RegisterModules(ContainerBuilder builder, IServiceCollection services);
}