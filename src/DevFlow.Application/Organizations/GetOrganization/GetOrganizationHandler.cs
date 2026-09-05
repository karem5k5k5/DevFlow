using DevFlow.Application.Abstractions;

namespace DevFlow.Application.Organizations.GetOrganization;

public sealed class GetOrganizationHandler
{
    private readonly IOrganizationRepository _repository;

    public GetOrganizationHandler(
        IOrganizationRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetOrganizationResult?> Handle(
        GetOrganizationQuery query,
        CancellationToken cancellationToken)
    {
        var organization =
            await _repository.GetByIdAsync(
                query.Id,
                cancellationToken);

        if (organization is null)
        {
            return null;
        }

        return new GetOrganizationResult(
            organization.Id,
            organization.Name);
    }
}