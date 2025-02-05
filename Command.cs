public abstract class Command
{
    public string Name { get; init; }

    public Command(string name)
    {
        this.Name = name;
    }

    public abstract void Execute();
}

public class CreateTodoCommand : Command
{
    public CreateTodoCommand()
        : base("create-todo") { }

    public override void Execute()
    {
        Console.WriteLine("TODO: Create a todo object.");
    }
}

public class DeleteTodoCommand : Command
{
    public DeleteTodoCommand()
        : base("delete-todo") { }

    public override void Execute()
    {
        Console.WriteLine("TODO: Delete a todo object.");
    }
}

// Services kan även kallas:
// Managers
// Handler
public interface ICommandService
{
    void ExecuteCommand(string input);
}

public class DefaultCommandService : ICommandService
{
    private Command[] commands = [new CreateTodoCommand(), new DeleteTodoCommand()];

    public void ExecuteCommand(string input)
    {
        foreach (Command command in commands)
        {
            if (command.Name.Equals(input))
            {
                command.Execute();
                return;
            }
        }

        Console.WriteLine("No such command found.");
    }
}
