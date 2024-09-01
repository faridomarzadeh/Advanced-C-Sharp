
using DemoLibrary;

public class Program
{
    public static void Main(string[] args)
    {
        Manager accountingVP = new Manager();

        accountingVP.FirstName = "Emma";
        accountingVP.LastName = "Stone";
        accountingVP.CalculatePerHourRate(4);

        Employee employee = new Employee();

        employee.FirstName = "Tim";
        employee.LastName = "Corey";
        employee.AssignManager(accountingVP);
        employee.CalculatePerHourRate(2);

        Console.WriteLine($"{employee.FirstName}'s salary is ${employee.Salary}/hour.");

        Console.ReadLine();
    }
}