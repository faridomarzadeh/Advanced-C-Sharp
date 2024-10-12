

using Autofac;
using ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        var container = ContainerConfig.Config();

        using(var scope = container.BeginLifetimeScope())
        {
            var app = scope.Resolve<IApplication>();
            app.Run();
        }
        Console.ReadLine();
    }
}