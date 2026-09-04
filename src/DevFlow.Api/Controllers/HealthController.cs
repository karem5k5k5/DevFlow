using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(
            new
            {
                status = "Ok"
            }
        );
    }
}