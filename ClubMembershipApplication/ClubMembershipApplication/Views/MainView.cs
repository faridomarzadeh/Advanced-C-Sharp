using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class MainView : IView
    {
        private IView _registerView = null;
        private IView _loginView = null;
        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Please enter 'l' for login, or if you are not registered press 'r' to register.");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunUserLoginView();
            }
            else if (key == ConsoleKey.L)
            {
                RunUserLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye.");
                Console.ReadKey();
            }
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();
        }
        private void RunUserLoginView()
        {
            _loginView.RunView();
        }
    }
}
