namespace Employees.Starter;

public class HelpCommand : Command
{

    protected override string Module => "help";

    protected override string Action => "view";

    protected override string HelpString => "view help";

    private readonly List<ICommand> possibleCommands;

    public HelpCommand(List<ICommand> possibleCommands)
    {
        this.possibleCommands = possibleCommands;
    }

    protected override void ExecuteInternal(string[] args)
    {
        foreach (var possibleCommand in possibleCommands)
        {
            Console.WriteLine(possibleCommand.Description);
        }
    }
}