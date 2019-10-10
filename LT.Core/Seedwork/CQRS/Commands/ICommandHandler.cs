using MediatR;

namespace LT.Core.Seedwork.CQRS.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : class, ICommand
    { }
}
