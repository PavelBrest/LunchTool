using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.CQRS.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event, CancellationToken token = default)
            where TEvent : class, IEvent;
    }
}
