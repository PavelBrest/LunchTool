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
    [HandlerDecorator(typeof(ValidateRequestDecorator<ChangeUserEmail, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<ChangeUserName, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<ChangeUserPassword, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<ChangeUserSurname, Unit>))]
    internal class UserCommandsHandler :
        ICommandHandler<RegisterUser>,
        ICommandHandler<ChangeUserEmail>,
        ICommandHandler<ChangeUserName>,
        ICommandHandler<ChangeUserPassword>,
        ICommandHandler<ChangeUserSurname>
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

        public async Task<Unit> Handle(ChangeUserEmail request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }

        public async Task<Unit> Handle(ChangeUserName request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }

        public async Task<Unit> Handle(ChangeUserPassword request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }

        public async Task<Unit> Handle(ChangeUserSurname request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
