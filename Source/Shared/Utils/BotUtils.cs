using bubas.Source.Shared.Constants;
using DotNetEnv;

namespace bubas.Source.Shared.Utils;

public static class BotUtils
{
    public static string GetBotApiKey()
    {
        var apiKey = Env.GetString(Destination.BotApi);
        return apiKey;
    }
}