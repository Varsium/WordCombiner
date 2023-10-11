using MediatR;

namespace WordCombiner.Application.Calculation
{
    public sealed record CalculationRequest(int CombinationLength, List<string> Items) : IRequest<IList<string>>;
}
