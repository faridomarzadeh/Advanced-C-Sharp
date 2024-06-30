using ClubMembershipApplication.Data;
using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator: IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 100;

        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;


        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        IRegister _register = null;
        delegate bool EmailExistsDel(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternMatchValidDel _patternMatchValidDel = null;
        CompareFieldsValidDel _compareFieldsValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get 
            {
                if(_fieldArray == null )
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;
        public void InitializeValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);

            _requiredValidDel = CommonFieldValidatorFunctions.RequiredValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions .DateValidDel;
            _patternMatchValidDel = CommonFieldValidatorFunctions .PatternMatchValidDel;
            _compareFieldsValidDel = CommonFieldValidatorFunctions .CompareFieldsValidDel;

            _emailExistsDel = new EmailExistsDel(EmailExists);
        }

        private bool EmailExists(string emailAddress)
        {
            return _register.EmailExists(emailAddress);
        }

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;
            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;//convert int to enum

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern)) ? $"you must enter a valid email address {Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && _emailExistsDel(fieldValue)) ? $"This Email Address already exists. Please try a different one{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField),userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_stringLengthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Min_Length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_stringLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password  must contain at least 1 small-case letter, 1 capital letter, 1 special character and length should be between 6-10 characters{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_compareFieldsValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password])) ? $"your entry did not match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_dateValidDel(fieldValue,out DateTime validDateTime)) ?$"you did not enter a valid date {Environment.NewLine}": fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern))? $"you did not enter a valid phone number {Environment.NewLine}": string.Empty;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"you miust enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern)) ? $"you did not enter a valid postal code {Environment.NewLine}" : string.Empty;
                    break;
                default:
                    throw new ArgumentException("This field does not exist");

            }
            return (fieldInvalidMessage==string.Empty);
        }
    }
}
