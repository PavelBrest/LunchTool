using System;
using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;

namespace LT.Core.Contracts.Places.Commands
{
    public class CreatePlace : ICommand
    {
        public CreatePlace()
        { }

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

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDeadline { get; set; }
        public DateTime StartServeTime { get; set; }
        public DateTime EndServeTime { get; set; }
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
