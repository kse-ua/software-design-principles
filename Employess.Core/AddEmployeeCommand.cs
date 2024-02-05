namespace Employees.Starter;

using Domain;

public class AddEmployeeCommand : Command
{
    protected override string Module => "employee";

    protected override string Action => "add";

    private readonly IEmployeeRegistry registry;

    public AddEmployeeCommand(IEmployeeRegistry registry)
    {
        this.registry = registry;
    }

    protected override void ExecuteInternal(string[] args)
    {
        var name = args[0];
        registry.Add(name);
        Console.WriteLine($"Employee {name} added!");
    }

}