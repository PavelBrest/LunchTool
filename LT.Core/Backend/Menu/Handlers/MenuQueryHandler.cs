using AutoMapper;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.Menu.Queries;
using LT.Core.Contracts.Menu.Views;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Query;
using LT.Core.Seedwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Backend.Menu.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<GetMenu, GetMenuView>))]
    internal class MenuQueryHandler :
        IQueryHandler<GetMenu, GetMenuView>
    {
        private readonly IReadonlyRepository<Menu> _repository;
        private readonly IMapper _mapper;

        public MenuQueryHandler(IReadonlyRepository<Menu> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task<GetMenuView> Handle(GetMenu request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll()
                                   .Where(p => p.Id == request.Id);

            return _mapper.ProjectTo<GetMenuView>(query)
                          .SingleAsync();
        }
    }
}
