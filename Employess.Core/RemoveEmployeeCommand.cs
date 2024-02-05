namespace Employees.Starter;

using Domain;

public class RemoveEmployeeCommand : Command
{
    protected override string Module => "employee";

    protected override string Action => "remove";

    private readonly IEmployeeRegistry registry;

    public RemoveEmployeeCommand(IEmployeeRegistry registry)
    {
        this.registry = registry;
    }

    protected override void ExecuteInternal(string[] args)
    {
        var name = args[0];
        if (registry.GetAll().All(employee => employee.Name != name))
        {
            Console.WriteLine("No such employee, can not remove");
            return;
        }
        
        registry.Remove(name);
        Console.WriteLine($"Employee {name} removed!");
    }
}