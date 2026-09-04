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
    public IActionResult Create(CreateOrganizationRequest request)
    {
        var command = new CreateOrganizationCommand(request.Name);

        var result = _handler.Handle(command);

        return Created(
            $"/api/v1/organizations/{result.Id}",
            result);
    }
}