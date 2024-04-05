namespace DesignPatterns.Singleton;
public static class CacheManager
{
    private static ICache? Cache;
    private static readonly object _lock = new();
    public static ICache GetCache()
    {
        lock (_lock)
        {
            if (Cache is null)
                Cache = new InMemoryCache();
        }
        return Cache;
    }
}

