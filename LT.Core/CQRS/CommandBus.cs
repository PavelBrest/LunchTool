using LT.Core.Seedwork.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.CQRS
{
    internal sealed class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Send<TCommand>(TCommand command, CancellationToken token = default)
            where TCommand : class, ICommand
        {
            return _mediator.Send(command, token);
        }
    }
}
