using AutoMapper;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.User.Commands;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Backend.Users.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<RegisterUser, Unit>))]
    internal class UserCommandsHandler :
        ICommandHandler<RegisterUser>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserCommandsHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);
            await _repository.AddAsync(entity);

            return Unit.Value;
        }
    }
}
