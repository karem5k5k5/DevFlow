using DevFlow.Api.Contracts.Organizations;
using DevFlow.Application.Abstractions;
using DevFlow.Application.Organizations.CreateOrganization;
using DevFlow.Application.Organizations.GetOrganization;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Api.Controllers;

[ApiController]
[Route("api/v1/organizations")]
public sealed class OrganizationsController : ControllerBase
{
    private readonly ICommandHandler<CreateOrganizationCommand, CreateOrganizationResult> _handler;
    private readonly GetOrganizationHandler _getHandler;

    public OrganizationsController(
    ICommandHandler<
        CreateOrganizationCommand,
        CreateOrganizationResult> createHandler,
    GetOrganizationHandler getHandler)
    {
        _handler = createHandler;
        _getHandler = getHandler;
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
    public async Task<IActionResult> GetById(
    Guid id,
    CancellationToken cancellationToken)
    {
        var query = new GetOrganizationQuery(id);

        var result = await _getHandler.Handle(
            query,
            cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}