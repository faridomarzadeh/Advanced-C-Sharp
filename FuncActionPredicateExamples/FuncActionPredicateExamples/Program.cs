
using System.Reflection.Metadata.Ecma335;

class Program
{
    delegate TResult Func2<out TResult>();
    delegate TResult Func2<in T, out TResult>(T arg);
    delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    delegate TResult Func2<in T1,in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
    public static void Main(string[] args)
    {
        Func<decimal, decimal, decimal> AnnualSalary = (baseSalary, bonusPercentage) => { return baseSalary + (baseSalary * (bonusPercentage / 100)); };
        Console.WriteLine($" Total Annual Salary {AnnualSalary(100000, 10)}");

        // Actions

        Action<int, string,string, decimal, bool> displayEmployee = (id, firstName,lastName, salary, isManager) =>
        {
            string output = $"Id: {id}{Environment.NewLine}First Name: {firstName}{Environment.NewLine}Last Name: {lastName}{Environment.NewLine}Salary: {salary}{Environment.NewLine}Manager: {isManager}";
            Console.WriteLine(output);
            Console.WriteLine("================================");
        };

        //displayEmployee(1, "Tim", "Johnson", 120000, false);

        List<Employee> employees = new List<Employee>();
        employees.Add(new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Thomson",
            AnnualSalary = AnnualSalary(60000,10),
            IsManager = true,
            Gender = 'M'
        });
        employees.Add(new Employee
        {
            Id = 2,
            FirstName = "Jake",
            LastName = "Silver",
            AnnualSalary = AnnualSalary(40000,5),
            IsManager = false,
            Gender = 'M'
        });
        employees.Add(new Employee
        {
            Id = 3,
            FirstName = "Sarah",
            LastName = "Kough",
            AnnualSalary = AnnualSalary(30000,5),
            IsManager = false,
            Gender = 'F'
        });
        employees.Add(new Employee
        {
            Id = 4,
            FirstName = "Jessica",
            LastName = "Johnson",
            AnnualSalary = AnnualSalary(70000,10),
            IsManager = true,
            Gender = 'F'
        });

        var filteredEmployees = employees.FilterEmployee(e => e.IsManager == true);
        foreach(Employee employee in filteredEmployees)
        {
            displayEmployee(employee.Id,employee.FirstName, employee.LastName,employee.AnnualSalary,employee.IsManager);
        }
    }

}

public static class Extensions
{
    public static List<Employee> FilterEmployee(this List<Employee> employees, Predicate<Employee> predicate)
    {
        List<Employee> result = new List<Employee>();
        foreach (Employee employee in employees)
        {
            if (predicate(employee))
            {
                result.Add(employee);
            }
        }
        return result;
    }
}
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public char Gender {  get; set; }
    public bool IsManager { get; set; }

}

