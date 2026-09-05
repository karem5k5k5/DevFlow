using DevFlow.Application.Abstractions;
using DevFlow.Domain.Organizations;

namespace DevFlow.Application.Organizations.CreateOrganization;

public sealed class CreateOrganizationHandler
    : ICommandHandler<
        CreateOrganizationCommand,
        CreateOrganizationResult>
{
    private readonly IOrganizationRepository _repository;

    public CreateOrganizationHandler(
        IOrganizationRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateOrganizationResult> Handle(
        CreateOrganizationCommand command,
        CancellationToken cancellationToken)
    {
        var organization =
            Organization.Create(command.Name);

        await _repository.AddAsync(
            organization,
            cancellationToken);

        await _repository.SaveChangesAsync(
            cancellationToken);

        return new CreateOrganizationResult(
            organization.Id,
            organization.Name);
    }
}