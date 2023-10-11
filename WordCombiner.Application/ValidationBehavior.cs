using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace WordCombiner.Application;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

  

    private static void HandleValidationResult(TRequest request, ValidationResult result)
    {
        if (!result.IsValid) throw new ValidationException("validation Failed", result.Errors);
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(request, cancellationToken);
                HandleValidationResult(request, result);
            }

        return await next();
    }
}