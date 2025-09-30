using bubas.Source.Core.Entities;
using bubas.Source.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace bubas.Source.Infrastructure.Data;

public sealed class BotDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProfileAnnouncement> ProfileAnnouncements { get; set; }
    public DbSet<WeatherData> WeatherData { get; set; }
    public DbSet<StudentSchedule> StudentSchedules { get; set; }
    
    public BotDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DbUtils.GetDbConnectionString());
    }
}