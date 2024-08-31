using OCPLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary.Applicant
{
    public class ExecutiveModel : IApplicants
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccounts AccountProcessor { get; set; } = new ExecutiveAccounts();
    }
}
