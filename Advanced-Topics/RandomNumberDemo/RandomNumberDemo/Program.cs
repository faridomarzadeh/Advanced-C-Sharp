
namespace RandomNumberDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                CorrectRandomMethod(random);
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                WrongRandomMethod();
            }
            List<PersonModel> people = new List<PersonModel>()
            {
                new PersonModel{ FirstName = "Tim" },
                new PersonModel{ FirstName = "Jack" },
                new PersonModel{ FirstName = "Jimmy" },
                new PersonModel{ FirstName = "Leslie" },
                new PersonModel{ FirstName = "Donald" },
                new PersonModel{ FirstName = "Peter" },
                new PersonModel{ FirstName = "Paul" }
            };

            var sortedPeople = people.OrderBy(x => random.Next());

            foreach (var person in sortedPeople)
            {
                Console.WriteLine(person.FirstName);
            }
            
            Console.ReadLine();
        }

        private static void CorrectRandomMethod(Random random)
        {
            Console.WriteLine(random.Next());
        }

        private static void WrongRandomMethod()
        {
            Random random = new Random();
            Console.WriteLine(random.Next());
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
    }
}