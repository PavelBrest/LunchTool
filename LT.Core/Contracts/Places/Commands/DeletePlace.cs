using System;
using LT.Core.Seedwork.CQRS.Commands;
using FluentValidation;

namespace LT.Core.Contracts.Places.Commands
{
    public class DeletePlace : ICommand
    {
        public DeletePlace()
        { }

        public DeletePlace(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class DeletePlaceValidator : AbstractValidator<DeletePlace>
    {
        public DeletePlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
