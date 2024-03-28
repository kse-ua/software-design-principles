namespace Recommendations.BusinessLayer.API;

using DataLayer.API;

public interface IUserService
{
    bool TryCreateUser(string id);
}

class UserService : IUserService
{
    private IUserRepository repository;
    
    public bool TryCreateUser(string id)
    {
        var user = repository.GetUser(id);
        if (user == null)
        {
            return false;
        }

        repository.CreateUser(id);
        return true;
    }
}