using bubas.Source.Core.Entities;
using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace bubas.Source.Infrastructure.Repositories;

public class AnnouncementRepository(PooledDbContextFactory<BotDbContext> dbPool) : BaseRepository(dbPool), IAnnouncementRepository
{
    public async Task<Announcement?> GetById(long id) =>
        await ExecuteAsync(async db => await db.ProfileAnnouncements.FirstOrDefaultAsync(pa => pa.Id == id));

    public async Task<bool> Merge(Announcement entity) => 
        await ExecuteAsync(async db =>
        {
            db.ProfileAnnouncements.Update(entity);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(long id) =>
        await ExecuteAsync(async db =>
        {
            var profileAnnouncement = await db.ProfileAnnouncements.FirstAsync(p => p.Id == id);
            db.ProfileAnnouncements.Remove(profileAnnouncement);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(Announcement entity) =>
        await ExecuteAsync(async db =>
        {
            db.ProfileAnnouncements.Remove(entity);
            await db.SaveChangesAsync();
        });
}