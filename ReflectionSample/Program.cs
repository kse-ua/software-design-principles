// See https://aka.ms/new-console-template for more information
using System.Web;

var employee = new Employee("Ann", 18);
PrintConstructorInfo(employee);
Console.WriteLine($"{HttpUtility.UrlEncode("A+++B")}");

void PrintConstructorInfo(object o)
{
    var constructors = o.GetType().GetConstructors();
    foreach (var constructor in constructors)
    {
        Console.WriteLine($"constructor {constructor}");
        foreach (var parameter in constructor.GetParameters())
        {
            Console.WriteLine(parameter);
        }

    }
}

public class Employee
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}