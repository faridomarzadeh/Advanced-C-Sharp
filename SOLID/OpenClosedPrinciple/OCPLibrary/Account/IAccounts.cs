using OCPLibrary.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary.Account
{
    public interface IAccounts
    {
        EmployeeModel Create(IApplicants person);
    }
}
