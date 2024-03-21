namespace Employees.Starter;

public interface ICommand
{
    void Execute();
    
}

public interface IReversable
{
    ICommand CreateReverseCommand();
}

public abstract class Command : ICommand
{

    public abstract void Execute();
}
