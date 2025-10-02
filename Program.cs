using bubas.Source.Bootstrap.Installers;
using bubas.Source.Core.Interfaces;
using bubas.Source.Shared.Constants;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

namespace bubas;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            await Startup();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await Task.CompletedTask;
        }
    }

    private static async Task Startup()
    {
        LoadEnvs();
        var container = SetupContainer();
        await StartBot(container);
    }

    private static void LoadEnvs()
    {
        Env.Load(Destination.EnvFilePath);
    }

    private static IServiceProvider SetupContainer()
    {
        IDiInstaller diInstaller = new DefaultDiInstaller();
        var container = diInstaller.InstallDiContainer();
        
        return container;
    }

    private static async Task StartBot(IServiceProvider container)
    {
        var botStarter = container.GetService<IBotStarter>();

        if (botStarter == null)
        {
            throw new Exception("Bot starter not found");
        }
        
        await botStarter.StartBot();
    }
}