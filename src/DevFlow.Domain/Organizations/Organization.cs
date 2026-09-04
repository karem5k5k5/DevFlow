using DevFlow.Domain.Common.Exceptions;

namespace DevFlow.Domain.Organizations;

public sealed class Organization
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    private Organization()
    {
        // Required by EF Core later.
    }

    private Organization(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Organization Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Organization name is required.");
        }

        name = name.Trim();

        if (name.Length > 100)
        {
            throw new DomainException("Organization name cannot exceed 100 characters.");
        }

        return new Organization(Guid.NewGuid(), name);
    }
}