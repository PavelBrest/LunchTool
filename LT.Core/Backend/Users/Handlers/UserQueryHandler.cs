using AutoMapper;
using AutoMapper.QueryableExtensions;
using LT.Core.Backend.Decorators;
using LT.Core.Contracts.User.Queries;
using LT.Core.Contracts.User.Views;
using LT.Core.CQRS;
using LT.Core.Seedwork.CQRS.Query;
using LT.Core.Seedwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Backend.Users.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<LoginUser, LoginUserView>))]
    internal class UserQueryHandler :
        IQueryHandler<LoginUser, LoginUserView>,
        IQueryHandler<GetUserInfo, GetUserInfoView>
    {
        private readonly IReadonlyRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserQueryHandler(IReadonlyRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoginUserView> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var find = await _repository.GetAll()
                                        .Where(p => p.Login == request.Login && p.Password == request.Password)
                                        .ProjectTo<LoginUserView>(_mapper.ConfigurationProvider)
                                        .SingleOrDefaultAsync();

            if (find == null)
                //TODO: add business exception
                throw new Exception();

            return find;
        }

        public async Task<GetUserInfoView> Handle(GetUserInfo request, CancellationToken cancellationToken)
        {
            var find = await _repository.GetAll()
                                        .Where(p => p.Id == request.Id)
                                        .ProjectTo<GetUserInfoView>(_mapper.ConfigurationProvider)
                                        .SingleOrDefaultAsync();

            if (find == null)
                //TODO: add business exception
                throw new Exception();

            return find;

        }
    }
}
