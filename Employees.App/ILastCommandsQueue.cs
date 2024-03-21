namespace Employees.Starter;

public interface ILastCommandsQueue
{
    void AddCommand(ICommand command);
    
    List<ICommand> GetLastCommands();
}

public class LastCommandsQueue : ILastCommandsQueue
{
    private readonly List<ICommand> lastCommands = new ();
    public void AddCommand(ICommand command)
    {
        if (command is IReversable reversable)
        {
            lastCommands.Add(reversable.CreateReverseCommand());
        }
    }

    public List<ICommand> GetLastCommands() => lastCommands;
}