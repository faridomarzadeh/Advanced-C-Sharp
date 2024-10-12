
using ConsoleUI;
using DemoLibrary.Chore;
using DemoLibrary.Persons;

public class Program
{
    static void Main(string[] args)
    {
        IPerson owner = Factory.CreatePerson();
        owner.FirstName = "Tim";
        owner.LastName = "Corey";
        owner.EmailAddress = "tim@iamtimcorey.com";
        owner.PhoneNumber = "1234567890";

        IChore chore = Factory.CreateChore();
        chore.Owner = owner;
        chore.ChoreName = "take out the trash";

        chore.PerformedWork(4);
        chore.PerformedWork(1.5);
        chore.CompleteChore();

        Console.ReadLine();
    }
}