namespace DesignPatterns.Singleton
{
    public interface ICache
    {
        public Task<object> Get(string key);
        public Task<bool> Set(string key, object value);

    }
}
