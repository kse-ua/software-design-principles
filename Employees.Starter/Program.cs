using DI.Core;
using Employee.Setup;
using Employees.Domain;

var diContainer = new DiContainer();
diContainer.Register<IEmployeeRegistry, EmployeeRegistry>(Scope.Singleton);

var factory = new InputActionsFactory(diContainer);
var actions = factory.GetAllActions();
while (true)
{
    var input = Console.ReadLine();
    if (!TryHandle(input))
    {
        Console.WriteLine($"Unknown command '{input}', please try again");
    }
}

bool TryHandle(string input)
{
    foreach (var inputAction in actions)
    {
        if (inputAction.CanHandle(input))
        {
            var command = inputAction.GetCommand(input);
            command.Execute();
            return true;
        }
    }

    return false;
}