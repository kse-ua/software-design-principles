// See https://aka.ms/new-console-template for more information
using Employee.Setup;
using Employees.Domain;

var commandFactory = new CommandFactory(new EmployeeRegistry());
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