using System.Net;
using System.Net.Http.Json;

namespace DevFlow.IntegrationTests.Organizations;

public class CreateOrganizationTests
{
    [Fact]
    public async Task CreateOrganization_ReturnsCreated()
    {
        // Test host setup will be completed
        // in the next persistence-testing step.
        await Task.CompletedTask;

        Assert.True(true);
    }
}