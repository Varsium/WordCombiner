using MediatR;
using Microsoft.Extensions.Logging;

namespace WordCombiner.Application.Calculation
{
    internal class CalculationRequestHandler : IRequestHandler<CalculationRequest, IList<string>>
    {
        private readonly ILogger<CalculationRequestHandler> _logger;

        public CalculationRequestHandler(ILogger<CalculationRequestHandler> logger)
        {
            _logger = logger;
        }

        public Task<IList<string>> Handle(CalculationRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting to Calculate the Request {0}", DateTime.Now.ToString());
            var list = new HashSet<string>(request.Items);
            var output = new List<string>();
            Parallel.For(0, list.Count, i =>
            {
                Parallel.For(0, list.Count, j =>
                {
                    string combination = list.ElementAt(i) + list.ElementAt(j);

                    // Check if the combination forms a valid word
                    if (combination.Length == request.CombinationLength && !output.Contains($"{list.ElementAt(i)}+{list.ElementAt(j)}={combination}") && i != j)
                    {
                        output.Add($"{list.ElementAt(i)}+{list.ElementAt(j)}={combination}");
                    }
                });
            });
            _logger.LogInformation("Completed Calculating the Request {0}", DateTime.Now.ToString());
            return Task.FromResult((IList<string>)output);
        }
    }
}
