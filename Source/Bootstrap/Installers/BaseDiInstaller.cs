using Autofac;
using bubas.Source.Core.Interfaces;

namespace bubas.Source.Bootstrap.Installers;

public abstract class BaseDiInstaller : IDiInstaller
{
    public IContainer InstallDiContainer()
    {
        var builder = new ContainerBuilder();
        RegisterModules(builder);
        
        var container = builder.Build(); 
        
        return container;
    }
    
    protected abstract void RegisterModules(ContainerBuilder builder);
}