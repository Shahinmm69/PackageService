namespace Package.Application.UseCases.Subscription.Commands.CreateSubscription
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionCommand, int>
    {
        private readonly ISubscriptionRepository _repo;
        private readonly IRedisCache _redis;

        public CreateSubscriptionHandler(ISubscriptionRepository repo, IRedisCache redis)
        {
            _repo = repo;
            _redis = redis;
        }

        public async Task<int> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = new Domain.Entities.Subscription
            {
                UserId = request.UserId,
                Plan = request.Plan,
                MaxItems = request.MaxItems
            };

            var created = await _repo.AddAsync(subscription, cancellationToken);

            await _redis.SetSubscriptionAsync(created);

            return subscription.Id;
        }
    }
}