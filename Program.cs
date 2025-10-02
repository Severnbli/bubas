using bubas.Source.Bootstrap.Installers;
using bubas.Source.Core.Interfaces;
using bubas.Source.Shared.Constants;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using TelegramBotBase;

namespace bubas;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            await ProcessProgram();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await Task.CompletedTask;
        }
    }

    private static async Task ProcessProgram()
    {
        LoadEnvs();
        var container = SetupContainer();
        var bot = await StartBot(container);
        
        Console.WriteLine("Bot started!\nPress enter to stop...");
        Console.ReadLine();
        
        await bot.Stop();
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

    private static async Task<BotBase> StartBot(IServiceProvider container)
    {
        var botStarter = container.GetService<IBotStarter>();

        if (botStarter == null)
        {
            throw new Exception("Bot starter not found");
        }
        
        return await botStarter.StartBot();
    }
}