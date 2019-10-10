using AutoMapper;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.Menu.Commands;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("LT.Core.Tests")]
namespace LT.Core.Backend.Menu.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<CreateMenu, Unit>))]
    internal class MenuCommandsHandler
        : ICommandHandler<CreateMenu>
    {
        private readonly IRepository<Menu> _repository;
        private readonly IMapper _mapper;

        public MenuCommandsHandler(IRepository<Menu> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<Unit> Handle(CreateMenu request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Menu>(request);

            await _repository.AddAsync(entity);

            return Unit.Value;
        }
    }
}
