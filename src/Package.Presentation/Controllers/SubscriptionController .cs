using Package.Application.UseCases.Subscription.Commands.CreateSubscription;
using Package.Application.UseCases.Subscription.Commands.UpdateSubscription;
using Package.Application.UseCases.Subscription.Queries.GetByUserId;
using Package.Application.UseCases.Subscription.Queries.GetLastUpdated;

namespace Package.Presentation.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscriptionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("last-updated")]
        public async Task<IActionResult> GetLastUpdated([FromQuery] GetLastUpdatedQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-user-id")]
        public async Task<IActionResult> GetByUserId([FromQuery] GetByUserIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
