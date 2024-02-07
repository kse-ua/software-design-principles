namespace Employees.Starter;

using Domain;

[InputAction]
public class RemoveEmployeeInputAction : InputAction<RemoveEmployeeCommand>
{
    protected override string Module => "employee";

    protected override string Action => "remove";
    
    protected override string HelpString => "remove an employee";

    private readonly IEmployeeRegistry employeeRegistry;

    public RemoveEmployeeInputAction(IEmployeeRegistry employeeRegistry)
    {
        this.employeeRegistry = employeeRegistry;
    }

    protected override RemoveEmployeeCommand GetCommandInternal(string[] args)
    {
        return new RemoveEmployeeCommand(employeeRegistry, args[0]);
    }
}


[Command]
public class RemoveEmployeeCommand : Command
{
    private string name;

    private readonly IEmployeeRegistry registry;

    public RemoveEmployeeCommand(IEmployeeRegistry registry, string name)
    {
        this.name = name;
        this.registry = registry;
    }

    public override void Execute()
    {
        if (registry.GetAll().All(employee => employee.Name != name))
        {
            Console.WriteLine("No such employee, can not remove");
            return;
        }
        
        registry.Remove(name);
        Console.WriteLine($"Employee {name} removed!");
    }
}