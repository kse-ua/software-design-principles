namespace Delivery.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class SampleController : ControllerBase
{
    [HttpGet("ping")]
    public async Task<IActionResult> ProcessRtdn([FromHeader] string apikey)
    {
        return Ok();
    }
}