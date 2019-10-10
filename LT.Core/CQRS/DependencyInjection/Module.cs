using LT.Core.CQRS.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LT.Core.CQRS.DependencyInjection
{
    public abstract class Module : IModule
    {
        public virtual void Configure(IServiceCollection services)
        { }

        public virtual void Use()
        { }
    }
}
