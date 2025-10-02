using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using bubas.Source.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace bubas.Source.Bootstrap.Modules;

public class DbModule : IDiModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<PooledDbContextFactory<BotDbContext>>();
        
        serviceCollection.AddSingleton<IProfileRepository, ProfileRepository>();
        serviceCollection.AddSingleton<IProfileAnnouncementRepository, ProfileAnnouncementRepository>();
        serviceCollection.AddSingleton<IWeatherDataRepository, WeatherDataRepository>();
        serviceCollection.AddSingleton<IStudentScheduleRepository, StudentScheduleRepository>();
    }
}