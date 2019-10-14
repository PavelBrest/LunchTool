using System;
using System.Collections.Generic;
using System.Text;

namespace LT.Core.Contracts.User.Views
{
    public class GetUserInfoView
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}
