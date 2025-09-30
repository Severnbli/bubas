using bubas.Source.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace bubas.Source.Infrastructure.Repositories;

public abstract class BaseRepository
{
    public BaseRepository(PooledDbContextFactory<BotDbContext> dbPool)
    {
        _dbPool = dbPool;
    }
    
    protected PooledDbContextFactory<BotDbContext> _dbPool;

    protected async Task<TResult?> ExecuteAsync<TResult>(
        Func<BotDbContext, Task<TResult>> action,
        TResult? defaultValue = default)
    {
        try
        {
            await using var dbContext = await _dbPool.CreateDbContextAsync();
            return await action(dbContext);
        }
        catch (Exception e)
        {
            return defaultValue;
        }
    }

    protected async Task<bool> ExecuteAsync(Func<BotDbContext, Task> action)
    {
        try
        {
            await using var dbContext = await _dbPool.CreateDbContextAsync();
            await action(dbContext);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}