using DevFlow.Domain.Organizations;

namespace DevFlow.Application.Organizations.CreateOrganization;

public sealed class CreateOrganizationHandler
{
    public CreateOrganizationResult Handle(
        CreateOrganizationCommand command)
    {
        var organization = Organization.Create(command.Name);

        return new CreateOrganizationResult(
            organization.Id,
            organization.Name);
    }
}