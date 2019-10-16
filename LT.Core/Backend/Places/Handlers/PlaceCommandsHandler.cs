using AutoMapper;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.Places.Commands;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Backend.Places.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<CreatePlace, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<DeletePlace, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<UpdatePlace, Unit>))]
    internal class PlaceCommandsHandler :
        ICommandHandler<CreatePlace>,
        ICommandHandler<DeletePlace>,
        ICommandHandler<UpdatePlace>
    {
        private readonly IRepository<Place> _repository;
        private readonly IMapper _mapper;

        public PlaceCommandsHandler(IRepository<Place> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<Unit> Handle(CreatePlace request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Place>(request);

            await _repository.AddAsync(entity);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeletePlace request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Place>(request);

            await _repository.DeleteAsync(entity);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePlace request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Place>(request);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
