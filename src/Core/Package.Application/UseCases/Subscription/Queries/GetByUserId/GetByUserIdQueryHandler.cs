namespace Package.Application.UseCases.Subscription.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, Domain.Entities.Subscription?>
    {
        private readonly ISubscriptionRepository _repo;

        public GetByUserIdQueryHandler(ISubscriptionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Domain.Entities.Subscription?> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByUserIdAsync(request.userId, cancellationToken);
        }
    }
}
