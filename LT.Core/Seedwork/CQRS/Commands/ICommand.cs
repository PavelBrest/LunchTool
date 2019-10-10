using MediatR;

namespace LT.Core.Seedwork.CQRS.Commands
{
    public interface ICommand : IRequest<Unit>
    { }
}
