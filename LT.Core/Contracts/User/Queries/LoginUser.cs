using FluentValidation;
using LT.Core.Contracts.User.Views;
using LT.Core.Seedwork.CQRS.Query;

namespace LT.Core.Contracts.User.Queries
{
    public class LoginUser : IQuery<LoginUserView>
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
                                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z]{1,})(?=.*\d)[\S]{6,25}$");
        }
    }
}
