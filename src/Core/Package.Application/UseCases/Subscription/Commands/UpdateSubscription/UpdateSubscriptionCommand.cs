namespace Package.Application.UseCases.Subscription.Commands.UpdateSubscription
{
    public record UpdateSubscriptionCommand(int UserId, string Plan, int MaxItems) : IRequest<Unit>;
}
