namespace Employee.Setup;

using System.Reflection;
using DI.Core;
using Employees.Domain;
using Employees.Starter;

public class InputActionsFactory : IInputCommandFactory
{
    private readonly IDiContainer diContainer;

    public InputActionsFactory(IDiContainer diContainer)
    {
        this.diContainer = diContainer;
    }

    public List<IInputAction> GetAllActions()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        var commandTypes = GetAllAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsAbstract)
            .Where(type => type.GetCustomAttribute(typeof(InputActionAttribute)) != null)
            .Where(type => type.IsAssignableTo(typeof(IInputAction)));

        var result = new List<IInputAction>();
        foreach (var type in commandTypes)
        {
            result.Add(diContainer.Instantiate<IInputAction>(type));
        }
        var helpCommand = new HelpInputAction(result);
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