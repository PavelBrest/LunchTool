using LT.Core.Seedwork.CQRS.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.CQRS
{
    internal sealed class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Publish<TEvent>(TEvent @event, CancellationToken token = default)
            where TEvent : class, IEvent
        {
            return _mediator.Publish(@event, token);
        }
    }
}
