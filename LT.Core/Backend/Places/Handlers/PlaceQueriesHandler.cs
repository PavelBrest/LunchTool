using AutoMapper;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.Places.Queries;
using LT.Core.Contracts.Places.Views;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Query;
using LT.Core.Seedwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace LT.Core.Backend.Places.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<GetPlace, PlaceView>))]
    internal class PlaceQueriesHandler :
        IQueryHandler<GetPlace, PlaceView>,
        IQueryHandler<GetPlaces,IReadOnlyList<PlaceView>>
    {
        private readonly IReadonlyRepository<Place> _repository;
        private readonly IMapper _mapper;

        public PlaceQueriesHandler(IReadonlyRepository<Place> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task<PlaceView> Handle(GetPlace request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll()
                                   .Where(p => p.Id == request.Id);

            return _mapper.ProjectTo<PlaceView>(query)
                          .SingleAsync();
        }

        public Task<IReadOnlyList<PlaceView>> Handle(GetPlaces request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll();

            return Task.FromResult((IReadOnlyList<PlaceView>)new List<PlaceView>(_mapper.ProjectTo<PlaceView>(query).AsEnumerable()).AsReadOnly());
        }
    }
}