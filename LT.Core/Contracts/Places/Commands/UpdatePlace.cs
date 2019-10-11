using System;
using System.Collections.Generic;
using System.Text;
using LT.Core.Seedwork.CQRS.Commands;

namespace LT.Core.Contracts.Places.Commands
{
    public class UpdatePlace : ICommand
    {
        public UpdatePlace(Guid id, string name, string address, string phoneNumber, string comment, DateTime orderDeadline, DateTime startServeTime, DateTime endServeTime)
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
}
