using System;

namespace LT.Core.CQRS
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class HandlerDecoratorAttribute : Attribute
    {
        public Type Decorator { get; set; }

        public HandlerDecoratorAttribute(Type decorator)
        {
            Decorator = decorator;
        }
    }
}
