using DevFlow.Application.Organizations.CreateOrganization;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Api.Controllers;

[ApiController]
[Route("api/v1/organizations")]
public sealed class OrganizationsController : ControllerBase
{
    private readonly CreateOrganizationHandler _handler;

    public OrganizationsController(CreateOrganizationHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public IActionResult Create(CreateOrganizationCommand command)
    {
        var result = _handler.Handle(command);

        return Created(
            $"/api/v1/organizations/{result.Id}",
            result);
    }
}