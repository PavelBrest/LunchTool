using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;
using System;

namespace LT.Core.Contracts.User.Commands
{
    public class RegisterUser : ICommand
    { 
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }

    internal class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Login).NotEmpty()
                                 .Length(4);

            RuleFor(p => p.Name).NotEmpty();

            RuleFor(p => p.EmailAddress).NotEmpty()
                                        .EmailAddress();

            RuleFor(p => p.Password).NotEmpty()
                                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z]{1,})(?=.*\d)[\S]{6,25}$");
        }
    }
}
