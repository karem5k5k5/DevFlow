using System.ComponentModel.DataAnnotations;

namespace DevFlow.Api.Contracts.Organizations;

public sealed record CreateOrganizationRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; init; } = string.Empty;
}