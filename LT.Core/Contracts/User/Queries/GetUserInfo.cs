using FluentValidation;
using LT.Core.Contracts.User.Views;
using LT.Core.Seedwork.CQRS.Query;
using System;

namespace LT.Core.Contracts.User.Queries
{
    public class GetUserInfo : IQuery<GetUserInfoView>
    {
        public Guid Id { get; set; }
    }

    internal class GetUserInfoValidator : AbstractValidator<GetUserInfo>
    {
        public GetUserInfoValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
