using DevFlow.Application.Organizations.CreateOrganization;

namespace DevFlow.UnitTests.Organizations;

public class CreateOrganizationHandlerTests
{
    [Fact]
    public void Handle_CreatesOrganization()
    {
        var handler = new CreateOrganizationHandler();

        var command = new CreateOrganizationCommand(
            "Acme Engineering");

        var result = handler.Handle(command);

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Acme Engineering", result.Name);
    }
}