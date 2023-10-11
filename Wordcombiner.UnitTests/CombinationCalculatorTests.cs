namespace Wordcombiner.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using FluentAssertions;
    using NSubstitute;
    using Microsoft.Extensions.Logging;
    using WordCombiner.Application.Calculation;

    [TestFixture]
    public class CombinationCalculatorTests
    {
        [Test]
        public async Task Calculate_ValidCombinations_ReturnsExpectedOutput()
        {
            // Arrange
            var logger = new LoggerFactory().CreateLogger<CalculationRequestHandler>();
            var request = new CalculationRequest
            (6, new List<string> { "cat", "dog", "rat" });
            var calculator = new CalculationRequestHandler(logger);

            // Act
            var result = await calculator.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().Contain("cat+rat=catrat", "dog+cat=dogcat", "cat+dog=catdog");
        }

        [Test]
        public async Task Calculate_EmptyInput_ReturnsEmptyOutput()
        {
            // Arrange
            var logger = new LoggerFactory().CreateLogger<CalculationRequestHandler>();
            var request = new CalculationRequest
            (6, new List<string>());
            var calculator = new CalculationRequestHandler(logger);

            // Act
            var result = await calculator.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        public async Task Calculate_InvalidCombinationLength_ReturnsEmptyOutput()
        {
            // Cannot use Substitute because proxy not allowed for internals.
            // var logger = Substitute.For<ILogger<CalculationRequestHandler>>();

            var logger = new LoggerFactory().CreateLogger<CalculationRequestHandler>();
            var request = new CalculationRequest
            (7, new List<string> { "cat", "dog", "rat" });
            var calculator = new CalculationRequestHandler(logger);

            // Act
            var result = await calculator.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }

}