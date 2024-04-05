using System.Text.Json;

namespace DesignPatterns.Singleton;
public class InMemoryCache : ICache
{
    public Dictionary<string, string> CacheData { get; } = new();
    public async Task<object> Get(string key)
    {
        var result = CacheData.TryGetValue(key, out string? value);
        if (result == false || value is null)
            return Task.FromResult(new object());

        var deserializedValue = JsonSerializer.Deserialize<object>(value);
        return deserializedValue;
    }

    public async Task<bool> Set(string key, object value)
    {
        var result = CacheData.TryAdd(key, JsonSerializer.Serialize(value));
        return result;
    }
}

