namespace Package.Infrustructure.Jobs
{
    public class CacheUpdater : BackgroundService
    {
        private readonly IRedisCache _redis;
        private readonly IServiceScopeFactory _serviceFactory;

        private byte[] _lastRowVersion = new byte[8];

        public CacheUpdater(IRedisCache redis, IServiceScopeFactory serviceFactory)
        {
            _redis = redis;
            _serviceFactory = serviceFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using var scope = _serviceFactory.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<ISubscriptionRepository>();

                var updatedSubs = await repo.GetLastUpdatedAsync(_lastRowVersion, cancellationToken);

                foreach (var s in updatedSubs)
                {
                    await _redis.SetSubscriptionAsync(s);
                    if (s.RowVersion.IsGreaterThan(_lastRowVersion))
                        _lastRowVersion = s.RowVersion;
                }

                await _redis.SetHeartbeatAsync();
                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }
    }
}
