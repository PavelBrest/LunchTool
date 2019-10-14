using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;
namespace LT.Core.Contracts.Menu.Commands
{
    public class DeleteMenu : ICommand
    {
        public Guid Id { get; set; }
    }

    internal class DeleteMenuValidator : AbstractValidator<DeleteMenu>
    {
        public DeleteMenuValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
