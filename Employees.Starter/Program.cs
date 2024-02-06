using DI.Core;
using Employee.Setup;
using Employees.Domain;

var diContainer = new DiContainer();
diContainer.Register<IEmployeeRegistry, EmployeeRegistry>(Scope.Singleton);

var commandFactory = new CommandFactory(diContainer);
var commands = commandFactory.GetAllCommands();
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
    foreach (var command in commands)
    {
        if (command.CanHandle(input))
        {
            command.Execute(input);
            return true;
        }
    }

    return false;
}