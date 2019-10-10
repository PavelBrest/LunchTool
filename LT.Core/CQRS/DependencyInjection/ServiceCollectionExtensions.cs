using FluentValidation;
using LT.Core.CQRS.DependencyInjection.Abstractions;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.CQRS.Events;
using LT.Core.Seedwork.CQRS.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LT.Core.CQRS.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCommandHandler<TCommand, THandler>(this IServiceCollection services)
               where TCommand : class, ICommand
               where THandler : class, ICommandHandler<TCommand>
        {
            var handlerType = typeof(THandler);

            var decorators = GetDecorators<TCommand>(handlerType)
                .Where(p => p.BaseType == typeof(CommandHandlerDecorator<TCommand>) ||
                    p.GetInterfaces().Contains(typeof(IPipelineBehavior<TCommand, Unit>)));

            foreach (var decor in decorators)
            {
                if (decor.BaseType == typeof(CommandHandlerDecorator<TCommand>))
                    services.AddTransient(typeof(CommandHandlerDecorator<TCommand>), decor);
                else
                    services.AddTransient(typeof(IPipelineBehavior<TCommand, Unit>), decor);
            }

            return services;
        }

        public static IServiceCollection RegisterQueryHandler<TQuery, Tout, THandler>(this IServiceCollection services)
            where TQuery : class, IQuery<Tout>
            where Tout : class
            where THandler : class, IQueryHandler<TQuery, Tout>
        {
            var handlerType = typeof(THandler);

            var decorators = GetDecorators<TQuery>(handlerType)
                .Where(p => p.BaseType == typeof(QueryHandlerDecorator<TQuery, Tout>) ||
                    p.BaseType == typeof(IPipelineBehavior<TQuery, Tout>));

            foreach (var decor in decorators)
            {
                if (decor.BaseType == typeof(QueryHandlerDecorator<TQuery, Tout>))
                    services.AddTransient(typeof(QueryHandlerDecorator<TQuery, Tout>), decor);
                else
                    services.AddTransient(typeof(IPipelineBehavior<TQuery, Tout>), decor);
            }

            return services;
        }

        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<IQueryBus, QueryBus>();
            services.AddTransient<IEventBus, EventBus>();

            return services;
        }

        public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
            where TModule : class, IModule
        {
            services.AddSingleton<TModule, TModule>();
            services.AddSingleton<IModule, TModule>(f => f.GetService<TModule>());
            services.BuildServiceProvider().GetService<TModule>().Configure(services);

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IEnumerable<Type> GetDecorators<T>(Type handler) =>
            handler.GetCustomAttributes(false)
                .Where(p => p is HandlerDecoratorAttribute)
                .Select(p => ((HandlerDecoratorAttribute)p).Decorator)
                .Where(p => p.GetGenericArguments().Contains(typeof(T)));

    }
}
