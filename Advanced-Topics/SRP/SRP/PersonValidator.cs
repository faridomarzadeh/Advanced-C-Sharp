using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                Console.WriteLine("You did not give us a valid first name!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                Console.WriteLine("You did not give us a valid last name");
                return false;
            }

            return true;
        }
    }
}
