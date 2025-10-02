using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Core.Interfaces;

public interface IDiModule
{
    public void Load(IServiceCollection  serviceCollection);
}