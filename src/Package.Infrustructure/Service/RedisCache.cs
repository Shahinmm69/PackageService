namespace Package.Infrustructure.Service
{
    public class RedisCache : IRedisCache
    {
        private readonly IDatabase _db;

        public RedisCache(string connection)
        {
            var conn = ConnectionMultiplexer.Connect(connection);
            _db = conn.GetDatabase();
        }

        public Task SetSubscriptionAsync(Subscription subscription)
        {
            var key = $"subscription:{subscription.UserId}";
            var json = JsonConvert.SerializeObject(subscription);
            return _db.StringSetAsync(key, json);
        }

        public Task SetHeartbeatAsync()
        {
            return _db.StringSetAsync(
                "packaging:heartbeat",
                DateTime.UtcNow.ToString("o"),
                TimeSpan.FromSeconds(15)
            );
        }
    }
}
