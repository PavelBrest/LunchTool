using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace LT.Core.Contracts.Places.Commands.Validators
{
    public class CreatePlaceValidator : AbstractValidator<CreatePlace> 
    {
        public CreatePlaceValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.OrderDeadline).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^([+]{1}375(33|29|25)[0-9]{7})$").When(x => x?.PhoneNumber != null);
        }
    }
}
