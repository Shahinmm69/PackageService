namespace Package.Application.UseCases.Subscription.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(int UserId, string Plan, int MaxItems) : IRequest<int>;
}
