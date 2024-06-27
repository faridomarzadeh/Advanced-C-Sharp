using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdministationAPI
{
    public abstract class EmployeeBase : IEmployee
    {
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public virtual decimal Salary { get; set; }
    }
}
