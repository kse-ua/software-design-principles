namespace Employee.Setup;

using Employees.Domain;
using Employees.Starter;

public class CommandFactory : ICommandFactory
{
    private readonly IEmployeeRegistry employeeRegistry;

    public CommandFactory(IEmployeeRegistry employeeRegistry)
    {
        this.employeeRegistry = employeeRegistry;
    }

    public List<ICommand> GetAllCommands()
    {
        return new List<ICommand>()
        {
            new AddEmployeeCommand(employeeRegistry),
            new RemoveEmployeeCommand(employeeRegistry),
            new ListEmployeesCommand(employeeRegistry),
        };
    }
}
