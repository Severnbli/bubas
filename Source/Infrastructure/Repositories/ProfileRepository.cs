using bubas.Source.Core.Entities;
using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace bubas.Source.Infrastructure.Repositories;

public class ProfileRepository(PooledDbContextFactory<BotDbContext> dbPool) : BaseRepository(dbPool), IProfileRepository
{
    public async Task<Profile?> GetById(long id) => 
        await ExecuteAsync(async db => await db.Profiles.FirstOrDefaultAsync(p => p.Id == id));

    public async Task<Profile?> GetByChatId(long chatId) =>
        await ExecuteAsync(async db => await db.Profiles.FirstOrDefaultAsync(p => p.ChatId == chatId));
    
    public async Task<bool> Merge(Profile entity) => 
        await ExecuteAsync(async db =>
        {
            db.Profiles.Update(entity);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(long id) => 
        await ExecuteAsync(async db =>
        {
            var profile = await db.Profiles.FirstAsync(p => p.Id == id);
            db.Profiles.Remove(profile);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(Profile entity) =>
        await ExecuteAsync(async db =>
        {
            db.Profiles.Remove(entity);
            await db.SaveChangesAsync();
        });
}