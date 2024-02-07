namespace Employees.Starter;

public interface ICommand
{
    void Execute();
    
}

public abstract class Command : ICommand
{

    public abstract void Execute();
}
