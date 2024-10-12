using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.MessageSender;

namespace DemoLibrary.Chore
{
    public class Chore : IChore
    {
        private readonly ILogger _logger;
        private readonly IMessageSender _messageSender;
        public Chore(ILogger logger, IMessageSender messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;
        }
        public string ChoreName { get; set; }
        public IPerson Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; set; }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            _logger.Log($"Performed work on {ChoreName}");
        }

        public void CompleteChore()
        {
            IsComplete = true;
            _logger.Log($" Completed {ChoreName}");

            _messageSender.SendMessage(Owner, $"The chore : {ChoreName}, is Complete.");
        }
    }
}
