using DevFlow.Application.Organizations.CreateOrganization;
using DevFlow.UnitTests.Organizations.Fakes;
using DevFlow.Domain.Common.Exceptions;

namespace DevFlow.UnitTests.Organizations;

public class CreateOrganizationHandlerTests
{
    [Fact]
    public async Task Handle_CreatesOrganization()
    {
        var repository = new FakeOrganizationRepository();

        var handler = new CreateOrganizationHandler(
            repository);

        var command = new CreateOrganizationCommand(
            "Acme Engineering");

        var result = await handler.Handle(
            command,
            CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal(
            "Acme Engineering",
            result.Name);
    }

    [Fact]
    public async Task Handle_WithInvalidName_Throws()
    {
        var repository = new FakeOrganizationRepository();

        var handler = new CreateOrganizationHandler(
            repository);

        var command = new CreateOrganizationCommand("");

        await Assert.ThrowsAsync<DomainException>(
            () => handler.Handle(
                command,
                CancellationToken.None));
    }
}