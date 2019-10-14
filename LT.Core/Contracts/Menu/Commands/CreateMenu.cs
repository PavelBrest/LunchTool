using FluentValidation;
using FluentValidation.Validators;
using LT.Core.Seedwork.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LT.Core.Tests")]
namespace LT.Core.Contracts.Menu.Commands
{
    public class CreateMenu : ICommand
    {
        public class DishInfo
        { 
            public Guid MenuId { get; set; }
            public Guid DishId { get; set; }
            public Guid TypeId { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }

        public IReadOnlyCollection<DishInfo> Dishes { get; set; }
    }

    internal class CreateMenuValidator : AbstractValidator<CreateMenu>
    {
        public CreateMenuValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.PlaceId).NotEmpty();
            RuleFor(p => p.Dishes).NotEmpty();
            RuleForEach(p => p.Dishes).SetValidator(new DishInfoValidator());
        }

        class DishInfoValidator : PropertyValidator
        {
            public DishInfoValidator() : base("Dishes must have MenuId, DishId and TypeId")
            { }

            protected override bool IsValid(PropertyValidatorContext context)
            {
                var item = context.PropertyValue as CreateMenu.DishInfo;

                if (item.DishId == default)
                {
                    context.MessageFormatter.AppendArgument("DishId", item.DishId);
                    return false;
                }
                else if (item.MenuId == default)
                {
                    context.MessageFormatter.AppendArgument("MenuId", item.MenuId);
                    return false;
                }
                else if (item.TypeId == default)
                {
                    context.MessageFormatter.AppendArgument("TypeId", item.TypeId);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(item.Description))
                {
                    context.MessageFormatter.AppendArgument("Description", item.Description);
                    return false;
                }

                return true;
            }
        }
    }
}
