namespace Package.Application.Contracts.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetLastUpdatedAsync(byte[] lastRowVersion, CancellationToken cancellationToken);
        Task<Subscription?> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task<Subscription> AddAsync(Subscription subscription, CancellationToken cancellationToken);
        Task UpdateAsync(Subscription subscription, CancellationToken cancellationToken);
    }
}