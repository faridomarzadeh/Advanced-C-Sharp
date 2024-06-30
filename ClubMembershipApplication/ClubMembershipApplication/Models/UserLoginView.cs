using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Models
{
    public class UserLoginView:IView
    {
        private ILogin _login = null;
        public UserLoginView(ILogin login)
        {
            _login = login;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");

            string userEmailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();

            User user = _login.Login(userEmailAddress, password);

            if (user != null)
            {
                WelcomeView welcomeView = new WelcomeView(user);
                welcomeView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials you entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
