using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.CQRS.Commands
{
    internal abstract class CommandHandlerDecorator<TCommand>
        : IPipelineBehavior<TCommand, Unit>
        where TCommand : class, ICommand
    {
        public abstract Task<Unit> Handle(TCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next);
    }
}
