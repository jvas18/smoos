using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Common.Pipelines
{
    public class ValidatorBehavior<TRequest, Unit> : IPipelineBehavior<TRequest, Unit>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<Unit> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<Unit> next)
        {
            var context = new ValidationContext<object>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(f => f != null)
                .ToList();

            return next();
        }
    }
}
