namespace Package.Application.Contracts.Services
{
    public interface IRedisCache
    {
        Task SetHeartbeatAsync();
        Task SetSubscriptionAsync(Subscription subscription);
    }
}