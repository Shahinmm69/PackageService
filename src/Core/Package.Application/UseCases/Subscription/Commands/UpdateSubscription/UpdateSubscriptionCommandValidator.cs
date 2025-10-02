namespace Package.Application.UseCases.Subscription.Commands.UpdateSubscription
{
    public class UpdateSubscriptionHandler : IRequestHandler<UpdateSubscriptionCommand, Unit>
    {
        private readonly ISubscriptionRepository _repo;
        private readonly IRedisCache _redis;

        public UpdateSubscriptionHandler(ISubscriptionRepository repo, IRedisCache redis)
        {
            _repo = repo;
            _redis = redis;
        }

        public async Task<Unit> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _repo.GetByUserIdAsync(request.UserId, cancellationToken);
            if (subscription == null) throw new KeyNotFoundException("Subscription not found");

            subscription.Plan = request.Plan;
            subscription.MaxItems = request.MaxItems;

            await _repo.UpdateAsync(subscription, cancellationToken);
            await _redis.SetSubscriptionAsync(subscription);

            return Unit.Value;
        }
    }

}
