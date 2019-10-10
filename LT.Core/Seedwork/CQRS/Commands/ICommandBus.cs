using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.CQRS.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command, CancellationToken token = default)
            where TCommand : class, ICommand;
    }
}
