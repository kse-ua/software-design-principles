namespace Employees.Starter;

public class HelpInputAction : InputAction<HelpCommand>
{

    protected override string Module => "help";

    protected override string Action => "view";

    protected override string HelpString => "view help";
    
    private readonly List<IInputAction> possibleCommands;

    public HelpInputAction(List<IInputAction> possibleCommands)
    {
        this.possibleCommands = possibleCommands;
    }


    protected override HelpCommand GetCommandInternal(string[] args)
    {
        return new HelpCommand(possibleCommands);
    }

}

public class HelpCommand : Command
{
    
    private readonly List<IInputAction> possibleCommands;

    public HelpCommand(List<IInputAction> possibleCommands)
    {
        this.possibleCommands = possibleCommands;
    }

    public override void Execute()
    {
        foreach (var possibleCommand in possibleCommands)
        {
            Console.WriteLine(possibleCommand.Description);
        }
    }
}