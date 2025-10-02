using Autofac;
using bubas.Source.Bootstrap.Installers;
using bubas.Source.Core.Interfaces;
using bubas.Source.Shared.Constants;
using DotNetEnv;

namespace bubas;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        LoadEnvs();
        var container = SetupContainer();
        await StartBot(container);
    }

    private static void LoadEnvs()
    {
        Env.Load(Destination.EnvFilePath);
    }

    private static IContainer SetupContainer()
    {
        IDiInstaller diInstaller = new DefaultDiInstaller();
        var container = diInstaller.InstallDiContainer();
        
        return container;
    }

    private static async Task StartBot(IContainer container)
    {
        var botStarter = container.Resolve<IBotStarter>();
        await botStarter.StartBot();
    }
}