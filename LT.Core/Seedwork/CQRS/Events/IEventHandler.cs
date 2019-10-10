using MediatR;

namespace LT.Core.Seedwork.CQRS.Events
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : class, IEvent
    { }


}
