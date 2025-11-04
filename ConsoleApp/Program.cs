using Storage;
using ConsoleApp;
class Program
{
    static void Main(string[] args)
    {
        IFileRepository repo = new TextFileRepository();
        var menu = new ConsoleMenu(repo);
        menu.Run();
    }
}
