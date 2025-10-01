using Autofac;
using bubas.Source.Bootstrap.Installers;
using bubas.Source.Core.Interfaces;

namespace bubas;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        IDiInstaller diInstaller = new DefaultDiInstaller();
        var container = diInstaller.InstallDiContainer();

        var botStarter = container.Resolve<IBotStarter>();
        await botStarter.StartBot();
    }
}