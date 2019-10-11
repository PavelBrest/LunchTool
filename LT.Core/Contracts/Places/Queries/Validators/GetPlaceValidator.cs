using FluentValidation;

namespace LT.Core.Contracts.Places.Queries.Validators
{
    public class GetPlaceValidator : AbstractValidator<GetPlace>
    {
        public GetPlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
