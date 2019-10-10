using Microsoft.Extensions.DependencyInjection;

namespace LT.Core.CQRS.DependencyInjection.Abstractions
{
    public interface IModule
    {
        void Configure(IServiceCollection services);
        void Use();
    }
}
