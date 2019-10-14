using System;
using LT.Core.Seedwork.CQRS.Commands;
using FluentValidation;

namespace LT.Core.Contracts.Places.Commands
{
    public class DeletePlace : ICommand
    {
        public DeletePlace(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class DeletePlaceValidator : AbstractValidator<DeletePlace>
    {
        public DeletePlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
