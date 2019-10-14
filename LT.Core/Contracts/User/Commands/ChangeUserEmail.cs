using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;

namespace LT.Core.Contracts.User.Commands
{
    public class ChangeUserEmail : ICommand
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
    }

    internal class ChangeUserEmailValidator : AbstractValidator<ChangeUserEmail>
    {
        public ChangeUserEmailValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.EmailAddress).NotEmpty()
                                 .EmailAddress();
        }
    }
}
