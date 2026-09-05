using DevFlow.Api.Infrastructure.Errors;
using DevFlow.Application.Abstractions;
using DevFlow.Application.Organizations.CreateOrganization;
using DevFlow.Application.Organizations.GetOrganization;
using DevFlow.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult>, CreateOrganizationHandler>();

builder.Services.AddScoped<GetOrganizationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();