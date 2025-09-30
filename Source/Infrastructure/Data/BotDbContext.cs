using bubas.Source.Shared.Utils;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace bubas.Source.Infrastructure.Data;

public sealed class BotDbContext : DbContext
{
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