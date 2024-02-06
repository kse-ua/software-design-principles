namespace Employee.Setup;

using Employees.Domain;
using Employees.Starter;
using Salaries;

public class CommandFactory : ICommandFactory
{
    private readonly IEmployeeRegistry employeeRegistry;

    public CommandFactory(IEmployeeRegistry employeeRegistry)
    {
        this.employeeRegistry = employeeRegistry;
    }

    public List<ICommand> GetAllCommands()
    {
        var result = new List<ICommand>()
        {
            new AddEmployeeCommand(employeeRegistry),
            new RemoveEmployeeCommand(employeeRegistry),
            new ListEmployeesCommand(employeeRegistry),
            new ShowSalaryCommand()
        };

        var helpCommand = new HelpCommand(result);
        result.Add(helpCommand);
        return result;
    }
}
