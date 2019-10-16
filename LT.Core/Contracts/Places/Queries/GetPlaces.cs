using System;
using System.Collections.Generic;
using System.Text;
using LT.Core.Contracts.Places.Views;
using LT.Core.Seedwork.CQRS.Query;
using FluentValidation;

namespace LT.Core.Contracts.Places.Queries
{
    public class GetPlaces : IListQuery<PlaceView>
    {
    }

    public class GetPlacesValidator : AbstractValidator<GetPlaces>
    {
    }
}
