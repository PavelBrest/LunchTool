using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;

namespace LT.Core.Contracts.User.Commands
{
    public class ChangeUserName : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    internal class ChangeUserNameValidator : AbstractValidator<ChangeUserName>
    {
        public ChangeUserNameValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
