using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;

namespace LT.Core.Contracts.User.Commands
{
    public class LoginUser : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    internal class LoginUserValidator : AbstractValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.Login).NotEmpty()
                                 .Length(4);

            RuleFor(p => p.Password).NotEmpty()
                                    .MinimumLength(6)
                                    .MaximumLength(25);
        }
    }
}
