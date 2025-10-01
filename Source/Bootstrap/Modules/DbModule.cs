using Autofac;
using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using bubas.Source.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace bubas.Source.Bootstrap.Modules;

public class DbModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PooledDbContextFactory<BotDbContext>>().AsSelf().SingleInstance();
        
        builder.RegisterType<ProfileRepository>().As<IProfileRepository>().SingleInstance();
        builder.RegisterType<ProfileAnnouncementRepository>().As<IProfileAnnouncementRepository>().SingleInstance();
        builder.RegisterType<WeatherDataRepository>().As<IWeatherDataRepository>().SingleInstance();
        builder.RegisterType<StudentScheduleRepository>().As<IStudentScheduleRepository>().SingleInstance();
    }
}