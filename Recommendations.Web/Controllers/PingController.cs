namespace Recommendations.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class PingController : ControllerBase
{
    
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok();
    }
}