using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessingLibrary
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        public string GenerateID(string firstName, string lastName)
        {
            return $"{GetPartOfName(firstName, 4)}{GetPartOfName(lastName, 4)}{DateTime.Now.Millisecond}";
        }

        private string GetPartOfName(string name, int length)
        {
            var output = name;
            if (name.Length > length)
            {
                output = name.Substring(0, length);
            }
            return output;
        }
    }
}
