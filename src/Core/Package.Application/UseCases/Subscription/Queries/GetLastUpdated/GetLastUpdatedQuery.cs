namespace Package.Application.UseCases.Subscription.Queries.GetLastUpdated
{
    public record GetLastUpdatedQuery(byte[]? LastRowVersion) : IRequest<IEnumerable<Domain.Entities.Subscription>>;
}
