namespace Employees.Starter;

[InputAction]
public class RevertInputAction : InputAction<RevertCommand>
{
    protected override string Module => "revert";

    protected override string Action => "last";

    protected override string HelpString => "Cntrl + Z";

    private readonly ILastCommandsQueue commandsQueue;

    public RevertInputAction(ILastCommandsQueue commandsQueue)
    {
        this.commandsQueue = commandsQueue;
    }

    protected override RevertCommand GetCommandInternal(string[] args)
    {
        return new RevertCommand(commandsQueue);
    }
}

[Command]
public class RevertCommand : Command
{
    private readonly ILastCommandsQueue commandsQueue;

    public RevertCommand(ILastCommandsQueue commandsQueue)
    {
        this.commandsQueue = commandsQueue;
    }

    public override void Execute()
    {
        var last = commandsQueue.GetLastCommands();
        if (!last.Any())
        {
            return;
        }
        var lastCommand = last[^1];
        lastCommand.Execute();
        last.Remove(lastCommand);
    }
}