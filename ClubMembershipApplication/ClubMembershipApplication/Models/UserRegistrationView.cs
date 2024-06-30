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
    public class UserRegistrationView : IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            _register = register;
            _fieldValidator = fieldValidator;
        }

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your enmail address ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please enter your first name ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please enter your last name ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please enter your password{Environment.NewLine} your password must contain at least 1 capital letter, 1 small case letter, 1 special character and the length must be between 6-10 characters ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please re-enter your password ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldConstants.UserRegistrationField.PhoneNumber, "Please enter your phone number ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your birth date ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressFirstLine, "Address (Line 1) ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressSecondLine, "Address (Line 2) ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressCity, "Please enter your City ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter your postal code ");
            RegisterUser();

        }
        private void RegisterUser()
        {
            _register.Register(_fieldValidator.FieldArray);
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("you have successfully registered, press any key to login.");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationField field,string promptText)
        {
            string fieldVal = string.Empty;
            do
            {
                Console.Write(promptText);
                fieldVal = Console.ReadLine();
            } while (!FieldValid(field,fieldVal));

            return fieldVal;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if(!_fieldValidator.ValidatorDel((int)field,fieldValue,_fieldValidator.FieldArray,out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }
            return true;
        }
    }
}
