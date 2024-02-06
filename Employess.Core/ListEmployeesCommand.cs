namespace Employees.Starter;

using Domain;

[Command]
public class ListEmployeesCommand : Command
{
    protected override string Module => "employee";

    protected override string Action => "list";

    private readonly IEmployeeRegistry registry;
    
    protected override string HelpString => "list all employee";


    public ListEmployeesCommand(IEmployeeRegistry registry)
    {
        this.registry = registry;
    }

    protected override void ExecuteInternal(string[] args)
    {
        var counter = 1;
        foreach (var employee in registry.GetAll())
        {
            Console.WriteLine($"{counter++}.\t{employee.Name}");
        }
    }
}