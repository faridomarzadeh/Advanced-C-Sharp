using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class AccountGenerator
    {
        public static void GenerateUsername(Person user)
        {
            Console.WriteLine($"Your username is {user.FirstName.Substring(1, 0)}{user.LastName}");
        }
    }
}
