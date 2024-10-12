using OCPLibrary.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary.Account
{
    public class ExecutiveAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicants person)
        {
            EmployeeModel employee = new EmployeeModel();
            employee.FirstName = person.FirstName;
            employee.LastName = person.LastName;
            employee.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acme.com";
            employee.IsManager = true;
            employee.IsExecutive = true;

            return employee;
        }
    }
}
