namespace Employees.Starter;

using Domain;

[InputAction]
public class ListEmployeeInputAction : InputAction<ListEmployeesCommand>
{
    protected override string Module => "employee";

    protected override string Action => "list";
    
    protected override string HelpString => "list all employee";

    private readonly IEmployeeRegistry employeeRegistry;

    public ListEmployeeInputAction(IEmployeeRegistry employeeRegistry)
    {
        this.employeeRegistry = employeeRegistry;
    }

    protected override ListEmployeesCommand GetCommandInternal(string[] args)
    {
        return new ListEmployeesCommand(employeeRegistry);
    }
}

[Command]
public class ListEmployeesCommand : Command
{
    private readonly IEmployeeRegistry registry;

    public ListEmployeesCommand(IEmployeeRegistry registry)
    {
        this.registry = registry;
    }

    public override void Execute()
    {
        var counter = 1;
        foreach (var employee in registry.GetAll())
        {
            Console.WriteLine($"{counter++}.\t{employee.Name}");
        }
    }
}