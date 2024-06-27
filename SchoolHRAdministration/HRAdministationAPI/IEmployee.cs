using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdministationAPI
{
    public interface IEmployee
    {
        int Id { get; set; }
        string FisrtName { get; set; }
        string LastName {  get; set; }
        decimal Salary {  get; set; }
    }
}
