namespace Clean.Infrastructure;

using Application.API;
using Domain;

public class UserRepository : IUserStorage, IUserExistChecker
{

    public bool SaveUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool IsUserExist(string id)
    {
        throw new NotImplementedException();
    }
}