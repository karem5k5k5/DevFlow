using DevFlow.Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Infrastructure.Persistence;

public sealed class DevFlowDbContext : DbContext
{
    public DevFlowDbContext(DbContextOptions<DevFlowDbContext> options) : base(options)
    {
    }

    public DbSet<Organization> Organizations => Set<Organization>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DevFlowDbContext).Assembly);
    }
}