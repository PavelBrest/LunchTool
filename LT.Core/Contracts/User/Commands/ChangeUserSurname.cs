using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;

namespace LT.Core.Contracts.User.Commands
{
    public class ChangeUserSurname : ICommand
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
    }

    public class ChangeUserSurnameValidator : AbstractValidator<ChangeUserSurname>
    {
        public ChangeUserSurnameValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Surname).NotEmpty();
        }
    }
}
