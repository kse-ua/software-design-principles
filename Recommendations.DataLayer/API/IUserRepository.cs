namespace Recommendations.DataLayer.API;

using Models;

public interface IUserRepository
{
    User GetUser(string id);
    User CreateUser(string id);
}