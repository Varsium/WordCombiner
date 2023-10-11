using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WordCombiner.Application;
using WordCombiner.Application.Calculation;

class Program
{
    private static readonly ServiceProvider _serviceProvider = new ServiceCollection()
        .AddLogging()
    .AddApplication()
    .BuildServiceProvider();
    async static Task Main()
    {

    start:
        Console.WriteLine("Paste the location of the Text File");
        var line = Console.ReadLine();
        var words = File.ReadAllLines(line).ToList();
        Console.WriteLine("Length of combinations");
        var parsed = int.TryParse(Console.ReadLine(), out var length);
        if (!parsed)
        {
            Console.WriteLine("Input was not an Integer.");
            goto start;
        }
        var sender = _serviceProvider.GetRequiredService<ISender>();
        try
        {
            var result = await sender.Send(new CalculationRequest(length, words));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"some validation failed {ex.Message} {ex.StackTrace}");
            goto start;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"something went wrong {ex.Message} {ex.StackTrace}");
            goto start;
        }

        Console.WriteLine("for Executing this program please press escape. else press any key.");
        var key = Console.ReadKey();
        if (key.Key != ConsoleKey.Escape)
        {
            goto start;
        }

        if (key.Key == ConsoleKey.Escape)
        {
            return;
        }
    }

}
