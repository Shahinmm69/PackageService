namespace Package.Application.UseCases.Subscription.Queries.GetByUserId
{
    public record GetByUserIdQuery(int userId) : IRequest<Domain.Entities.Subscription?>;
}
