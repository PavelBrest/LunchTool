using FluentValidation;
using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("LT.Core.Tests")]
namespace LT.Core.Backend.Decorators
{
    internal class ValidateRequestDecorator<TRequest, Tout> : IPipelineBehavior<TRequest, Tout>
        where TRequest : class, IRequest<Tout>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidateRequestDecorator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public Task<Tout> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            return next();
        }
    }
}