using FluentValidation;

namespace WordCombiner.Application.Calculation
{
    internal class CalculationRequestValidator : AbstractValidator<CalculationRequest>
    {
        public CalculationRequestValidator()
        {
            RuleFor(cr => cr.CombinationLength)
                .NotEmpty();
            RuleFor(cr => cr.CombinationLength)
                .NotEqual(0);
            RuleFor(cr => cr.Items)
                .NotEmpty();
            RuleFor(cr => cr.Items)
                .ChildRules(items =>
                 items
                 .RuleFor(i => i)
                 .NotEmpty()
                );
        }
    }
}
