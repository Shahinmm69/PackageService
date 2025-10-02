namespace Package.Application.UseCases.Subscription.Commands.UpdateSubscription
{
    public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required");

            RuleFor(x => x.Plan)
                .NotEmpty()
                .WithMessage("Plan is required")
                .MaximumLength(50)
                .WithMessage("Plan must be less than 50 character");

            RuleFor(x => x.MaxItems)
                .GreaterThan(0)
                .WithMessage("MaxItems must be greater than zero");
        }
    }
}
