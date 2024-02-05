namespace Employees.Domain;

public class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}