namespace Employees.Domain;

public interface IEmployeeRegistry
{
    Employee Add(string name);

    void Remove(string name);

    List<Employee> GetAll();
}

public class EmployeeRegistry : IEmployeeRegistry
{
    private static EmployeeRegistry instance;

    public static EmployeeRegistry Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EmployeeRegistry();
            }

            return instance;
        }
    }

    private readonly List<Employee> employees = new List<Employee>();

    public Employee Add(string name)
    {
        var employee = new Employee(name);
        employees.Add(employee);
        return employee;
    }

    public void Remove(string name)
    {
        var employee = employees.FirstOrDefault(e => e.Name == name);
        if (employee != null)
        {
            employees.Remove(employee);
        }
    }

    public List<Employee> GetAll()
    {
        return employees;
    }
}