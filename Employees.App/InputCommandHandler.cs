namespace Employees.Starter;

public interface IInputAction
{
    bool CanHandle(string command);

    ICommand GetCommand(string input);
    
    string Description { get; }
}

public abstract class InputAction<TCommand> : IInputAction where TCommand : ICommand
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

    public ICommand GetCommand(string input)
    {
        return GetCommandInternal(input.Split(" ")[2..]);
    }

    protected abstract TCommand GetCommandInternal(string[] args);

}

public class InputActionAttribute : Attribute
{
    
}