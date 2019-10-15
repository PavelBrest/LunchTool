using System;
using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;

namespace LT.Core.Contracts.Places.Commands
{
    public class CreatePlace : ICommand
    {
        public CreatePlace(Guid id, string name, string address, string phoneNumber, string comment, DateTime orderDeadline, DateTime startServeTime, DateTime endServeTime)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Comment = comment;
            OrderDeadline = orderDeadline;
            StartServeTime = startServeTime;
            EndServeTime = endServeTime;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string Comment { get; }
        public DateTime OrderDeadline { get; }
        public DateTime StartServeTime { get; }
        public DateTime EndServeTime { get; }
    }

    public class CreatePlaceValidator : AbstractValidator<CreatePlace>
    {
        public CreatePlaceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.OrderDeadline).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^([+]{1}375(33|29|25)[0-9]{7})$").When(x => x?.PhoneNumber != null);
        }
    }
}
