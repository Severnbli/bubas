using Autofac;
using bubas.Source.Bootstrap.Modules;

namespace bubas.Source.Bootstrap.Installers;

public class DiInstaller : BaseDiInstaller
{
    protected override void RegisterModules(ContainerBuilder builder)
    {
        builder.RegisterModule<DbModule>();
    }
}