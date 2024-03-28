namespace Clean.Application.UseCases;

using API;
using Domain;
using MediatR;

public class CreateUserCommand : IRequest<CreateUserResult>
{
    public string UserId { get; set; }
}

public class CreateUserResult
{
    public bool UserExists { get; set; }
    
    public bool UserCreated { get; set; }
}

class CreateUserUseCase : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private IUserExistChecker userExistChecker;

    private IUserStorage userStorage;

    public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (userExistChecker.IsUserExist(request.UserId))
        {
            return new CreateUserResult()
            {
                UserExists = true
            };
        }

        var user = new User();
        return new CreateUserResult()
        {
            UserCreated = userStorage.SaveUser(user)
        };
    }
}