using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WordCombiner.Application;
using WordCombiner.Application.Calculation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapPost("/Combination", async ([FromServices] ISender sender, [FromQuery] int combinationLength, [FromBody] List<string> words) =>
{
    try
    {
        var result = await sender.Send(new CalculationRequest(combinationLength, words));
        return Results.Ok(result);
    }
    catch (ValidationException ex)
    {
        return Results.BadRequest(new ProblemDetails() { Title = ex.Message, Detail = ex.StackTrace });
    }
    catch (Exception ex)
    {
        return Results.Problem(new ProblemDetails() { Title = ex.Message, Detail = ex.StackTrace });
    }
})
.WithName("Combination")
.Produces<List<string>>()
.Produces<ProblemDetails>(400)
.Produces<ProblemDetails>(500);
app.Run();
