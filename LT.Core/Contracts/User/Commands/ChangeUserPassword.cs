using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;

namespace LT.Core.Contracts.User.Commands
{
    public class ChangeUserPassword : ICommand
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    internal class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPassword>
    {
        public ChangeUserPasswordValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.OldPassword).NotEmpty()
                                       .Matches(@"^(?=.*[a-z])(?=.*[A-Z]{1,})(?=.*\d)[\S]{6,25}$");

            RuleFor(p => p.NewPassword).NotEmpty()
                                       .Matches(@"^(?=.*[a-z])(?=.*[A-Z]{1,})(?=.*\d)[\S]{6,25}$")
                                       .NotEqual(p => p.OldPassword);
        }
    }
}
