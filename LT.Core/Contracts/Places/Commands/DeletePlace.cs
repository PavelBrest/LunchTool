using System;
using System.Collections.Generic;
using System.Text;
using LT.Core.Seedwork.CQRS.Commands;

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
}
