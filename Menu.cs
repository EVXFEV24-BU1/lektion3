public abstract class Menu : DefaultCommandService
{
    public abstract void Display();
}

public class LoginMenu : Menu
{
    public LoginMenu(DependencyProvider dependencyProvider)
    {
        this.RegisterCommand(new LoginCommand(dependencyProvider));
    }

    public override void Display()
    {
        Console.WriteLine("Welcome! Please login by using the 'login' command.");
    }
}

public class MainMenu : Menu
{
    public MainMenu(DependencyProvider dependencyProvider)
    {
        this.RegisterCommand(new CreateTodoCommand(dependencyProvider));
        this.RegisterCommand(new DeleteTodoCommand(dependencyProvider));
    }

    public override void Display()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("create-todo - Create a todo");
        Console.WriteLine("delete-todo - Delete a todo");
    }
}

public interface IMenuService
{
    Menu GetCurrentMenu();
    void SetMenu(Menu menu);
}

public class SimpleMenuService : IMenuService
{
    private Menu menu;

    public Menu GetCurrentMenu()
    {
        return menu;
    }

    public void SetMenu(Menu menu)
    {
        this.menu = menu;
        this.menu.Display();
    }
}
