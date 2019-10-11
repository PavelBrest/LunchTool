using FluentValidation;
using LT.Core.Contracts.Menu.Views;
using LT.Core.Seedwork.CQRS.Query;
using System;

namespace LT.Core.Contracts.Menu.Queries
{
    public class GetMenu : IQuery<GetMenuView>
    {
        public Guid Id { get; set; }
    }

    internal class GetMenuValidator : AbstractValidator<GetMenu>
    {
        public GetMenuValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
