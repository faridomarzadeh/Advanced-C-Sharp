using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static RequiredValidDel RequiredValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);

                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);

                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }

        private static bool RequiredFieldValid(string fieldVal)
        {
            if(!string.IsNullOrEmpty(fieldVal))
                return true;

            return false;
        }

        private static bool StringLengthValid(string fieldVal,int min,int max) 
        {
            if(fieldVal.Length >= min &&  fieldVal.Length <= max)
                return true;

            return false;
        }

        private static bool DateFieldValid(string fieldVal, out DateTime validDateTime)
        {
            if(DateTime.TryParse(fieldVal, out validDateTime))
                return true;

            return false;
        }

        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern) 
        { 
            Regex regex = new Regex(regularExpressionPattern);
            if(regex.IsMatch(fieldVal))
                return true;

            return false;
        }

        private static bool FieldComparisonValid(string fieldFirst, string fieldSecond)
        {
            if(fieldFirst.Equals(fieldSecond))
                return true;

            return false;
        }
    }
}
