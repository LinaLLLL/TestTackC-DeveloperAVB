using Carter;
using FluentValidation;
using OrderService.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddMarten(option => { option.Connection(connectionString); })
    .UseLightweightSessions().InitializeWith<InitializeOrderDatabase>();

var assembly = typeof(Program).Assembly;


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

var app = builder.Build();

app.UseExceptionHandler(opt => { });

app.MapCarter();

app.Run();