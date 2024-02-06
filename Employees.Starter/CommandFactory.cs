namespace Employee.Setup;

using System.Reflection;
using DI.Core;
using Employees.Domain;
using Employees.Starter;
using Salaries;

public class CommandFactory : ICommandFactory
{
    private readonly IDiContainer diContainer;

    public CommandFactory(IDiContainer diContainer)
    {
        this.diContainer = diContainer;
    }

    public List<ICommand> GetAllCommands()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        var commandTypes = GetAllAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsAbstract)
            .Where(type => type.GetCustomAttribute(typeof(CommandAttribute)) != null)
            .Where(type => type.IsAssignableTo(typeof(Command)));

        var result = new List<ICommand>();
        foreach (var type in commandTypes)
        {
            result.Add(diContainer.Instantiate<ICommand>(type));
        }
        var helpCommand = new HelpCommand(result);
        result.Add(helpCommand);
        return result;
    }

    private IEnumerable<Assembly> GetAllAssemblies()
    {
        foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll"))
        {
            yield return Assembly.LoadFrom(file);
        }
        
    }
}