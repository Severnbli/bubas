using bubas.Source.Core.Entities;
using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace bubas.Source.Infrastructure.Repositories;

public class WeatherDataRepository(PooledDbContextFactory<BotDbContext> dbPool) : BaseRepository(dbPool), IWeatherDataRepository
{
    public async Task<WeatherData?> GetById(long id) =>
        await ExecuteAsync(async db => await db.WeatherData.FirstOrDefaultAsync(wd => wd.Id == id));

    public async Task<bool> Merge(WeatherData entity) =>
        await ExecuteAsync(async db =>
        {
            db.WeatherData.Update(entity);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(long id) =>
        await ExecuteAsync(async db =>
        {
            var weatherData = await db.WeatherData.FirstAsync(wd => wd.Id == id);
            db.WeatherData.Remove(weatherData);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(WeatherData entity) =>
        await ExecuteAsync(async db =>
        {
            db.WeatherData.Remove(entity);
            await db.SaveChangesAsync();
        });
}