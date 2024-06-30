using ClubMembershipApplication;
using ClubMembershipApplication.Views;

public class Program
{
    public static void Main(string[] args)
    {
        IView mainView = Factory.GetMainViewObject();
        mainView.RunView();

        Console.ReadKey();
    }
}