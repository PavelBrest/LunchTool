using System;
using System.Collections.Generic;
using System.Text;

namespace LT.Core.Contracts.Places.Views
{
    public class PlaceView
    {
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
