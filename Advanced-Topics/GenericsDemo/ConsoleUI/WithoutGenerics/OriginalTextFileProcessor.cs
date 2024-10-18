using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.WithoutGenerics
{
    public static class OriginalTextFileProcessor
    {
        public static void SavePeopleToTextFile(List<Person> people, string fileName)
        {
            List<string> text = new List<string>();
            string header = "FirstName,IsAlive,LastName";
            text.Add(header);
            foreach (Person person in people)
            {
                string entry = $"{person.FirstName},{ person.IsAlive},{person.LastName}";
                text.Add(entry);
            }
            File.WriteAllLines(fileName, text);
        }

        public static void SaveLogsToTextFile(List<LogEntry> logs, string fileName)
        {
            List<string> text = new List<string>();
            string header = "ErrorCode,Message,EventTime";
            text.Add(header);
            foreach (LogEntry log in logs)
            {
                string entry = $"{log.ErrorCode},{log.Message},{log.EventTime}";
                text.Add(entry);
            }
            File.WriteAllLines(fileName, text);
        }

        public static List<LogEntry> GetLogs(string fileName)
        {
            List<LogEntry> logs = new List<LogEntry>();
            var lines = File.ReadAllLines(fileName).ToList();
            if (lines.Count < 2)
                throw new Exception("Empty File");
            lines.RemoveAt(0);

            foreach(var  line in lines)
            {
                LogEntry logEntry = new LogEntry();
                var values = line.Split(',');
                logEntry.ErrorCode = int.Parse(values[0]);
                logEntry.Message = values[1];
                logEntry.EventTime = DateTime.Parse(values[2]);
                logs.Add(logEntry);
            }

            return logs;
        }

        public static List<Person> GetPeople(string fileName)
        {
            List<Person> people = new List<Person>();
            var lines = File.ReadAllLines(fileName).ToList();
            if (lines.Count < 2)
                throw new Exception("Empty File");
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                Person person = new Person();
                var values = line.Split(',');
                person.FirstName = values[0];
                person.IsAlive = bool.Parse(values[1]);
                person.LastName = values[2];
                people.Add(person);
            }

            return people;
        }
    }
}
