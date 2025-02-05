public abstract class Command
{
    public string Name { get; init; }
    protected DependencyProvider dependencyProvider;

    public Command(string name, DependencyProvider dependencyProvider)
    {
        this.Name = name;
        this.dependencyProvider = dependencyProvider;
    }

    public abstract void Execute();
}

public class CreateTodoCommand : Command
{
    public CreateTodoCommand(DependencyProvider dependencyProvider)
        : base("create-todo", dependencyProvider) { }

    public override void Execute()
    {
        Console.WriteLine("TODO: Create a todo object.");
    }
}

public class DeleteTodoCommand : Command
{
    public DeleteTodoCommand(DependencyProvider dependencyProvider)
        : base("delete-todo", dependencyProvider) { }

    public override void Execute()
    {
        Console.WriteLine("TODO: Delete a todo object.");
    }
}

public class LoginCommand : Command
{
    public LoginCommand(DependencyProvider dependencyProvider)
        : base("login", dependencyProvider) { }

    public override void Execute()
    {
        Console.Write("Enter a username: ");
        string username = Console.ReadLine()!;
        Console.Write("Enter a password: ");
        string password = Console.ReadLine()!;

        if (username.Equals("Ironman") && password.Equals("tonystark"))
        {
            Console.WriteLine("You have logged in!");
            dependencyProvider.MenuService.SetMenu(new MainMenu(dependencyProvider));
        }
        else
        {
            Console.WriteLine("Wrong username or password.");
        }
    }
}

// Services kan även kallas:
// Managers
// Handler
public interface ICommandService
{
    void RegisterCommand(Command command);
    void ExecuteCommand(string input);
}

public class DefaultCommandService : ICommandService
{
    private List<Command> commands = new List<Command>();

    public void RegisterCommand(Command command)
    {
        this.commands.Add(command);
    }

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
