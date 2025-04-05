using StackExchange.Redis;

public class RedisService
{
    private readonly IConnectionMultiplexer _muxer;
    private readonly IDatabase _db;

    public RedisService(IConfiguration config)
    {
        var options = new ConfigurationOptions
        {
            EndPoints = { { config["Redis:Host"], Convert.ToInt32(config["Redis.Port"]) } },
            User = config["Redis.User"],
            Password = config["Redis.Password"],
        };

        _muxer = ConnectionMultiplexer.Connect(options);
        _db = _muxer.GetDatabase();
    }

    //NOTE: to set a value...
    public async Task SetValueAsync(string key, string value)
    {
        await _db.StringSetAsync(key, value);
    }

    //NOTE: to get a value
    public async Task<string?> GetValueAsync(string key)
    {
        return await _db.StringGetAsync(key);
    }
}