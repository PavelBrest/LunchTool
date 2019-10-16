using FluentValidation.TestHelper;
using LT.Core.Contracts.Places.Queries;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.GetPlacesTests
{
    public class GetPlacesValidationTester
    {
        private readonly GetPlacesValidator _validator;

        public GetPlacesValidationTester()
        {
            _validator = new GetPlacesValidator();
        }
    }
}
