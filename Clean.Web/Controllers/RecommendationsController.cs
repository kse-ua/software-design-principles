namespace Recommendations.Web.Controllers;

using Clean.Application.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class RecommendationsController : ControllerBase
{
    private Mediator mediator;
    
    [HttpPost("user")]
    public async Task<IActionResult> RegisterUser(string name)
    {
        var result = await mediator.Send(new CreateUserCommand()
        {
            UserId = name
        });
        if (result.UserExists)
        {
            return Conflict();
        }
        if (result.UserCreated)
        {
            return Ok();
        }
        
        return StatusCode(500);
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