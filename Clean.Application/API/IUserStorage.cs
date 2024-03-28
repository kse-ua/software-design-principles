namespace Clean.Application.API;

using Domain;

public interface IUserStorage
{
    bool SaveUser(User user);
}