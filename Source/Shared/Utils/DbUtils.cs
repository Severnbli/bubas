using bubas.Source.Shared.Constants;
using DotNetEnv;

namespace bubas.Source.Shared.Utils;

public static class DbUtils
{
    public static string GetDbConnectionString()
    {
        var dbName = Env.GetString(Destination.DbName);
        var connectionString = $"Data Source={dbName}";
        
        return connectionString;
    }
}