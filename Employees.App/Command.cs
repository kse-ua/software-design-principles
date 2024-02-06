namespace Employees.Starter;

public interface ICommand
{
    bool CanHandle(string command);
    void Execute(string input);
    
    string Description { get; }
}

public class CommandAttribute : Attribute
{
    
}

public abstract class Command : ICommand
{
    protected abstract string Module { get; }
    protected abstract string Action { get; }

    public string Description => $"{Module} {Action} > {HelpString}";
    
    protected abstract string HelpString { get; }

    public bool CanHandle(string command)
    {
        var split = command.Split(" ");
        if (Module != split[0])
        {
            return false;
        }
        
        if (Action != split[1])
        {
            return false;
        }

        return true;
    }

    public void Execute(string input)
    {
        ExecuteInternal(input.Split(" ")[2..]);
    }


    protected abstract void ExecuteInternal(string[] args);
}
