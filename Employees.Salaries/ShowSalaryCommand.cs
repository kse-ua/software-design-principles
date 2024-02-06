namespace Employee.Salaries;

using Employees.Starter;

public class ShowSalaryCommand : Command
{

    protected override string Module { get; }

    protected override string Action { get; }

    protected override string HelpString { get; }

    protected override void ExecuteInternal(string[] args)
    {
        throw new NotImplementedException();
    }
}