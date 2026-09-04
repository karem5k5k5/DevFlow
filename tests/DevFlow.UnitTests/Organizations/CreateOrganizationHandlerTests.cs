using DevFlow.Application.Organizations.CreateOrganization;
using DevFlow.Application.Abstractions;

namespace DevFlow.UnitTests.Organizations;

public class CreateOrganizationHandlerTests
{
    [Fact]
    public void Handle_CreatesOrganization()
    {
        ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult> handler = new CreateOrganizationHandler();

        var command = new CreateOrganizationCommand(
            "Acme Engineering");

        var result = handler.Handle(command);

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Acme Engineering", result.Name);
    }

    [Fact]
    public void Handle_WithInvalidName_Throws()
    {
        ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult> handler = new CreateOrganizationHandler();

        var command = new CreateOrganizationCommand("");

        Assert.Throws<ArgumentException>(
            () => handler.Handle(command));
    }
}