using DevFlow.Domain.Organizations;

namespace DevFlow.Application.Abstractions;

public interface IOrganizationRepository
{
    Task AddAsync(
        Organization organization,
        CancellationToken cancellationToken);

    Task<Organization?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task SaveChangesAsync(
        CancellationToken cancellationToken);
}