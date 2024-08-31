using OCPLibrary;
using OCPLibrary.Account;
using OCPLibrary.Applicant;

public class Program
{
    public static void Main(string[] args)
    {
        List<IApplicants> applicants = new List<IApplicants>
        {
            new PersonModel { FirstName = "Tim", LastName="Corey" },
            new ManagerModel {FirstName = "Sue", LastName = "Storm"},
            new ExecutiveModel {FirstName = "Nancy", LastName = "Roman"}
        };

        List<EmployeeModel> employees = new List<EmployeeModel>();

        foreach(var applicant in applicants)
        {
            employees.Add(applicant.AccountProcessor.Create(applicant));
        }

        foreach(var employee in employees)
        {
            Console.WriteLine($"FirstName: {employee.FirstName}, LastName: {employee.LastName}, Email: {employee.EmailAddress}, IsManager: {employee.IsManager}, IsExecutive: {employee.IsExecutive}");
        }

        Console.ReadLine();
    }
}