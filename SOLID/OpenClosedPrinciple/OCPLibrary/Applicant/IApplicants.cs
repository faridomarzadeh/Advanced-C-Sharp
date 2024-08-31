using OCPLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary.Applicant
{
    public interface IApplicants
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        IAccounts AccountProcessor { get; set; }

    }
}
