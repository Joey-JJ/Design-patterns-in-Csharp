public class Program
{
    public static void Main(string[] args)
    {
        var todoList = new Project("Project 1", new TodoList[] {
            new Project("Project 1.1", new TodoList[] {
                new Project("Project 1.1.1", new TodoList[] {
                    new Todo("Todo")
                }),
                new Todo("Todo 1.1.2"),
                new Todo("Todo 1.1.3"),
            }),
            new Project("Project 1.2", new TodoList[] {
                new Todo("Todo 1.2.1"),
                new Todo("Todo 1.2.2"),
                new Todo("Todo 1.2.3"),
            }),
            new Todo("Todo 1.3"),
        });

        Console.WriteLine(todoList.getHtml());
    }
}

public interface TodoList // Component
{
    public string getHtml();
}

public record Todo(string text) : TodoList
{ // Leaf
    public string getHtml() => this.text;
}

public class Project : TodoList // Composite
{
    public string title;
    public TodoList[] todoLists;
    public Project(string title, TodoList[] todoLists)
    {
        this.title = title;
        this.todoLists = todoLists;
    }
    public string getHtml()
    {
        string output = $"<h1>{this.title}</h1><ul>";
        foreach (var i in this.todoLists)
            output += $"<li>{i.getHtml()}</li>";
        output += "</ul>";
        return output;
    }
}
