namespace Employees.Starter;

using Domain;

[InputAction]
public class AddEmployeeInputAction : InputAction<AddEmployeeCommand>
{
    protected override string Module => "employee";

    protected override string Action => "add";
    
    protected override string HelpString => "add an employee";

    private readonly IEmployeeRegistry employeeRegistry;

    public AddEmployeeInputAction(IEmployeeRegistry employeeRegistry)
    {
        this.employeeRegistry = employeeRegistry;
    }

    protected override AddEmployeeCommand GetCommandInternal(string[] args)
    {
        return new AddEmployeeCommand(employeeRegistry, args[0]);
    }
}

[Command]
public class AddEmployeeCommand : Command, IReversable
{

    private readonly string name;

    private readonly IEmployeeRegistry registry;

    public AddEmployeeCommand(IEmployeeRegistry registry, string name)
    {
        this.registry = registry;
        this.name = name;
    }

    public override void Execute()
    {
        registry.Add(name);
        Console.WriteLine($"Employee {name} added!");
    }

    public ICommand CreateReverseCommand()
    {
        return new RemoveEmployeeCommand(registry, name);
    }
}