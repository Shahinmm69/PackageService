namespace Package.Application.UseCases.Subscription.Queries.GetLastUpdated
{
    public class GetLastUpdatedHandler : IRequestHandler<GetLastUpdatedQuery, IEnumerable<Domain.Entities.Subscription>>
    {
        private readonly ISubscriptionRepository _repo;

        public GetLastUpdatedHandler(ISubscriptionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Domain.Entities.Subscription>> Handle(GetLastUpdatedQuery request, CancellationToken cancellationToken)
        {
            var lastRowVersion = request.LastRowVersion ?? new byte[8];
            return await _repo.GetLastUpdatedAsync(lastRowVersion, cancellationToken);
        }
    }
}
