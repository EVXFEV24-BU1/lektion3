class Program
{
    static void Main(string[] args)
    {
        // Kommandon:
        // 1. Skapa todos
        // 2. Radera todos
        // 3. Uppdatera todos

        // Service metoder:
        // 1. Skapa och validera todos, sedan spara todos

        // Repository metoder:
        // 1. Spara todos

        IMenuService menuService = new SimpleMenuService();
        ITodoRepository todoRepository = new ListTodoRepository();
        ITodoService todoService = new DefaultTodoService(todoRepository);
        DependencyProvider dependencyProvider = new DependencyProvider(
            menuService,
            todoRepository,
            todoService
        );

        menuService.SetMenu(new LoginMenu(dependencyProvider));

        while (true)
        {
            string command = Console.ReadLine()!;
            menuService.GetCurrentMenu().ExecuteCommand(command);
        }

        // Skriv '1' för att skapa en todo
    }
}

public class DependencyProvider
{
    public IMenuService MenuService { get; init; }
    public ITodoRepository TodoRepository { get; init; }
    public ITodoService TodoService { get; init; }

    public DependencyProvider(
        IMenuService menuService,
        ITodoRepository todoRepository,
        ITodoService todoService
    )
    {
        this.MenuService = menuService;
        this.TodoRepository = todoRepository;
        this.TodoService = todoService;
    }
}

// Service-pattern
// Repository-pattern
// Dependency injection
// Command-pattern (UI & UX)

public class Todo
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadlineDate { get; set; }

    public Todo(string title, string description, DateTime deadlineDate)
    {
        this.Title = title;
        this.DeadlineDate = deadlineDate;
        this.Description = description;
    }
}

public interface ITodoService
{
    void CreateTodo(string title, string description, DateTime deadlineDate);
    // void DeleteTodo(string title);
}

public class DefaultTodoService : ITodoService
{
    private ITodoRepository todoRepository;

    public DefaultTodoService(ITodoRepository todoRepository)
    {
        this.todoRepository = todoRepository;
    }

    public void CreateTodo(string title, string description, DateTime deadlineDate)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title may not be null or empty");
        }

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("Description may not be null or empty");
        }

        DateTime now = DateTime.Now;
        if (now.CompareTo(deadlineDate) > 0)
        {
            throw new ArgumentException("Deadline date has already passed.");
        }

        // Vi skulle kunna skicka mail och andra grejer här.

        Todo todo = new Todo(title, description, deadlineDate);
        todoRepository.SaveTodo(todo);
    }
}

public interface ITodoRepository
{
    void SaveTodo(Todo todo);
    // void Delete(string title);
}

public class ListTodoRepository : ITodoRepository
{
    private List<Todo> todos = new List<Todo>();

    public void SaveTodo(Todo todo)
    {
        this.todos.Add(todo);
    }
}

// public class DatabaseTodoRepository : ITodoRepository {}

// Databas
// Local storage
// List
// Test
