using DevFlow.Application.Abstractions;
using DevFlow.Domain.Organizations;

namespace DevFlow.UnitTests.Organizations.Fakes;

public sealed class FakeOrganizationRepository
    : IOrganizationRepository
{
    private readonly List<Organization> _organizations = [];

    public Task AddAsync(
        Organization organization,
        CancellationToken cancellationToken)
    {
        _organizations.Add(organization);

        return Task.CompletedTask;
    }

    public Task<Organization?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var organization = _organizations
            .SingleOrDefault(x => x.Id == id);

        return Task.FromResult(organization);
    }

    public Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}