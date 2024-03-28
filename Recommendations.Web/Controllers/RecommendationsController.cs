namespace Recommendations.Web.Controllers;

using BusinessLayer.API;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class RecommendationsController : ControllerBase
{
    private IUserService userService;

    public RecommendationsController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("user")]
    public IActionResult RegisterUser(string name)
    {
        return Ok();
    }
    
    [HttpPost("rate")]
    public IActionResult RateMovie(RateMovieRequest request)
    {
        return Ok();
    }
    
    [HttpGet("recommendation")]
    public IActionResult GetRecommendation(string user)
    {
        return Ok();
    }
}

public class RateMovieRequest
{
    public string Movie { get; init; }
    
    public string User { get; init; }
}