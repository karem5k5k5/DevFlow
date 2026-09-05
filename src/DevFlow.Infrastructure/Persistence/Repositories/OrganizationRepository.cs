using DevFlow.Application.Abstractions;
using DevFlow.Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Infrastructure.Persistence.Repositories;

public sealed class OrganizationRepository
    : IOrganizationRepository
{
    private readonly DevFlowDbContext _dbContext;

    public OrganizationRepository(
        DevFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        Organization organization,
        CancellationToken cancellationToken)
    {
        await _dbContext.Organizations.AddAsync(
            organization,
            cancellationToken);
    }

    public Task<Organization?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return _dbContext.Organizations
            .SingleOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}