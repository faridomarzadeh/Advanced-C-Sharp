using DemoLibrary.Persons;

namespace DemoLibrary.Chore
{
    public interface IChore
    {
        string ChoreName { get; set; }
        double HoursWorked { get; }
        bool IsComplete { get; set; }
        IPerson Owner { get; set; }

        void CompleteChore();
        void PerformedWork(double hours);
    }
}