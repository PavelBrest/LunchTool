using System;
using LT.Core.Contracts.Places.Views;
using LT.Core.Seedwork.CQRS.Query;
using FluentValidation;

namespace LT.Core.Contracts.Places.Queries
{
    public class GetPlace : IQuery<PlaceView>
    {
        public GetPlace()
        { }

        public GetPlace(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class GetPlaceValidator : AbstractValidator<GetPlace>
    {
        public GetPlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
