using bubas.Source.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Shared.Extensions;

public static class MicrosoftDiExtensions
{
    public static void RegisterModule<TModule>(this IServiceCollection serviceCollection) 
        where TModule : IDiModule, new()
    {
        var module = new TModule();
        module.Load(serviceCollection);
    }
    
    public static void RegisterModule<TModule>(this IServiceCollection serviceCollection, TModule module) 
        where TModule : IDiModule
    {
        module.Load(serviceCollection);
    }
}