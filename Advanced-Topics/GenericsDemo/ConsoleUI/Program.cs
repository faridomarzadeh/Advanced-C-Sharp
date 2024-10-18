
using ConsoleUI.Models;
using ConsoleUI.WithGenerics;
using ConsoleUI.WithoutGenerics;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter to continue");
            Console.ReadLine();

            DemonstrateTextFileStorage();
            Console.ReadKey();
        }
        private static void DemonstrateTextFileStorage()
        {
            var people = PersonPopulate();
            var logs = LogPopulate();

            string peopleFile = @"C:\\Temp\people.csv";
            string logFile = @"C:\\Temp\logs.csv";

            //OriginalTextFileProcessor.SavePeopleToTextFile(people, peopleFile);
            //OriginalTextFileProcessor.SaveLogsToTextFile(logs, logFile);

            //var loadedPeople = OriginalTextFileProcessor.GetPeople(peopleFile);
            //var loadedLogs = OriginalTextFileProcessor.GetLogs(logFile);

            GenericTextFileProcessor.SaveToTextFile<Person>(people,peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var loadedPeople = GenericTextFileProcessor.LoadFromFile<Person>(peopleFile);
            var loadedLogs = GenericTextFileProcessor.LoadFromFile<LogEntry>(logFile);


            foreach (var p in loadedPeople)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} IsAlive: {p.IsAlive}");
            }
            foreach (var log in loadedLogs)
            {
                Console.WriteLine($"{log.ErrorCode} {log.Message} at {log.EventTime.ToShortDateString()}");
            }

        }
        private static List<Person> PersonPopulate()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person
            {
                FirstName = "John",
                IsAlive = true,
                LastName = "Corey",
            });
            list.Add(new Person
            {
                FirstName = "Kias",
                IsAlive = false,
                LastName = "Dukes"
            });
            list.Add(new Person
            {
                FirstName = "Leslie",
                IsAlive = true,
                LastName = "Smith"
            });

            return list;
        }
        private static List<LogEntry> LogPopulate()
        {
            List<LogEntry> list = new List<LogEntry>();
            list.Add(new LogEntry
            {
                ErrorCode = 221,
                Message = "I woke up",
                EventTime = DateTime.Now
            });
            list.Add(new LogEntry
            {
                ErrorCode = 321,
                Message = "I Ate",
                EventTime = DateTime.Now
            });
            list.Add(new LogEntry
            {
                ErrorCode = 441,
                Message = "I Programmed",
                EventTime = DateTime.Now
            });

            return list;
        }
    }
}