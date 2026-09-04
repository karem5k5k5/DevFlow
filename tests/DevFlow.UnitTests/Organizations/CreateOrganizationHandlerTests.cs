using DevFlow.Domain.Common.Exceptions;
using DevFlow.Application.Abstractions;
using DevFlow.Application.Organizations.CreateOrganization;

namespace DevFlow.UnitTests.Organizations;

public class CreateOrganizationHandlerTests
{
    [Fact]
    public async Task Handle_CreatesOrganization()
    {
        ICommandHandler<
            CreateOrganizationCommand,
            CreateOrganizationResult> handler =
            new CreateOrganizationHandler();

        var command = new CreateOrganizationCommand(
            "Acme Engineering");

        var result = await handler.Handle(
            command,
            CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Acme Engineering", result.Name);
    }

    [Fact]
    public async Task Handle_WithInvalidName_Throws()
    {
        var handler = new CreateOrganizationHandler();

        var command = new CreateOrganizationCommand("");

        await Assert.ThrowsAsync<DomainException>(
            () => handler.Handle(
                command,
                CancellationToken.None));
    }
}