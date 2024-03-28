namespace Recommendations.DataLayer.Models;


public class User
{
    public string Id { get; init; }
    
    public List<UserReview> Reviews { get; set; }
}

public class Movie
{
    public string Id { get; init; }
}

public class UserReview
{
    public string UserId { get; init; }
    
    public string MovieId { get; init; }
}