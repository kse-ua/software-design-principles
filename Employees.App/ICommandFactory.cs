namespace Employees.Starter;

public interface ICommandFactory
{
    List<ICommand> GetAllCommands();
}