using bubas.Source.Core.Entities;
using bubas.Source.Core.Interfaces;
using bubas.Source.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace bubas.Source.Infrastructure.Repositories;

public class StudentScheduleRepository(PooledDbContextFactory<BotDbContext> dbPool) : BaseRepository(dbPool), IStudentScheduleRepository
{
    public async Task<StudentSchedule?> GetById(long id) =>
        await ExecuteAsync(async db => await db.StudentSchedules.FirstOrDefaultAsync(ss => ss.Id == id));

    public async Task<bool> Merge(StudentSchedule entity) => 
        await ExecuteAsync(async db =>
        {
            db.StudentSchedules.Update(entity);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(long id) =>
        await ExecuteAsync(async db =>
        {
            var studentSchedule = await db.StudentSchedules.FirstAsync(x => x.Id == id);
            db.StudentSchedules.Remove(studentSchedule);
            await db.SaveChangesAsync();
        });

    public async Task<bool> Delete(StudentSchedule entity) =>
        await ExecuteAsync(async db =>
        {
            db.StudentSchedules.Remove(entity);
            await db.SaveChangesAsync();
        });
}