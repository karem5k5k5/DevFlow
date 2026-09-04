using DevFlow.Domain.Organizations;
using DevFlow.Domain.Common.Exceptions;

namespace DevFlow.UnitTests.Organizations;

public class OrganizationTests
{
    [Fact]
    public void Create_WithValidName_CreatesOrganization()
    {
        var organization = Organization.Create("Acme Engineering");

        Assert.NotEqual(Guid.Empty, organization.Id);
        Assert.Equal("Acme Engineering", organization.Name);
    }

    [Fact]
    public void Create_TrimsName()
    {
        var organization = Organization.Create("  Acme Engineering  ");

        Assert.Equal("Acme Engineering", organization.Name);
    }

    [Fact]
    public void Create_WithEmptyName_Throws()
    {
        var exception = Assert.Throws<DomainException>(
            () => Organization.Create(""));
    }

    [Fact]
    public void Create_WithNameLongerThan100Characters_Throws()
    {
        var name = new string('A', 101);

        Assert.Throws<DomainException>(
            () => Organization.Create(name));
    }
}