using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LT.Core.Seedwork.CQRS.Commands;

namespace LT.Core.Contracts.Places.Commands
{
    public class CreatePlace : ICommand
    {
        public CreatePlace(string name, string address, string phoneNumber, string comment, DateTime orderDeadline, DateTime startServeTime, DateTime endServeTime)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Comment = comment;
            OrderDeadline = orderDeadline;
            StartServeTime = startServeTime;
            EndServeTime = endServeTime;
        }

        public string Name { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string Comment { get; }
        public DateTime OrderDeadline { get; }
        public DateTime StartServeTime { get; }
        public DateTime EndServeTime { get; }
    }
}
