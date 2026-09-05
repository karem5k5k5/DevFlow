using DevFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevFlow.Application.Abstractions;
using DevFlow.Infrastructure.Persistence.Repositories;

namespace DevFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DevFlow");

        services.AddDbContext<DevFlowDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<
        IOrganizationRepository,
        OrganizationRepository>();

        return services;
    }
}