namespace Movies.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult GetTest()
    {
        return Ok();
    }
}