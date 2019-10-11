using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Users
{
    public class User : IHasId<Guid>
    {
        public Guid Id { get; set; }

        object IHasId.Id => Id;

        public string Login { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
