using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Places
{
    public class Place : IHasId<Guid>
    {
        public Place()
        { }

        public Place(Guid id, string name, string address, string phoneNumber, string comment, DateTime orderDeadline, DateTime startServeTime, DateTime endServeTime)
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

        object IHasId.Id => Id;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDeadline { get; set; }
        public DateTime StartServeTime { get; set; }
        public DateTime EndServeTime { get; set; }
    }
}
