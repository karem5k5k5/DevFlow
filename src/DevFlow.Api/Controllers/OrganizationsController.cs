using DevFlow.Api.Contracts.Organizations;
using DevFlow.Application.Abstractions;
using DevFlow.Application.Organizations.CreateOrganization;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Api.Controllers;

[ApiController]
[Route("api/v1/organizations")]
public sealed class OrganizationsController : ControllerBase
{
    private readonly ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult> _handler;

    public OrganizationsController(ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult> handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    CreateOrganizationRequest request,
    CancellationToken cancellationToken)
    {
        var command = new CreateOrganizationCommand(request.Name);

        var result = await _handler.Handle(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return NotFound();
    }
}