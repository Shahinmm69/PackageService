namespace Package.Infrustructure.Persistence.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubscriptionRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Subscription>> GetLastUpdatedAsync(byte[] lastRowVersion, CancellationToken cancellationToken = default)
            => await _dbContext.Subscriptions
                            .AsNoTracking()
                            .Where(s => ApplicationDbContext.CompareRowVersions(s.RowVersion, lastRowVersion) > 0)
                            .OrderBy(s => s.RowVersion)
                            .ToListAsync(cancellationToken);

        public async Task<Subscription?> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
                => await _dbContext.Subscriptions
                            .AsNoTracking()
                            .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);

        public async Task<Subscription> AddAsync(Subscription subscription, CancellationToken cancellationToken = default)
        {
            await _dbContext.Subscriptions.AddAsync(subscription, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return subscription;
        }

        public async Task UpdateAsync(Subscription subscription, CancellationToken cancellationToken)
        {
            _dbContext.Subscriptions.Update(subscription);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
