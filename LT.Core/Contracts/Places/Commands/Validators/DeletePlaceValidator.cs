using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace LT.Core.Contracts.Places.Commands.Validators
{
    public class DeletePlaceValidator : AbstractValidator<DeletePlace>
    {
        public DeletePlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
