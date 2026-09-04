using DevFlow.Application.Abstractions;
using DevFlow.Domain.Organizations;

namespace DevFlow.Application.Organizations.CreateOrganization;

public sealed class CreateOrganizationHandler
    : ICommandHandler<
        CreateOrganizationCommand,
        CreateOrganizationResult>
{
    public Task<CreateOrganizationResult> Handle(
        CreateOrganizationCommand command,
        CancellationToken cancellationToken)
    {
        var organization = Organization.Create(command.Name);

        var result = new CreateOrganizationResult(
            organization.Id,
            organization.Name);

        return Task.FromResult(result);
    }
}