using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public static class Helper
    {
        public static int GetEmptyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 2;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 3;
            }
            return -1;
        }

        public static int GetBusyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 3;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 2;
            }
            return -1;
        }

        public static bool DoubleShiftIsValid(string assignedShift, string shiftToAssign)
        {
            if (assignedShift == "Morning" && shiftToAssign == "Evening")
            {
                return false;
            }

            if (assignedShift == "Evening" && shiftToAssign == "Morning")
            {
                return false;
            }

            if (assignedShift == shiftToAssign)
            {
                return false;
            }

            return true;

        }

        public static double ToDouble(string input)
        {
            
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double res);
            return res;
        }

        public static void ValidateInteger(string input, string fieldName, List<string> errors)
        {

            int number;
            if (!input.All(Char.IsDigit) || String.IsNullOrEmpty(input))
            {
                errors.Add($"{fieldName} : Enter a real number");
            }
            else
            {
                number = Convert.ToInt32(input);

                if (number < 0)
                {
                    errors.Add($"{fieldName} : Number should be positive");
                }
            }
           
        }
        public static void ValidateString(string input, string fieldName, List<string> errors)
        {
            if (String.IsNullOrEmpty(input))
            {
                errors.Add($"{fieldName} : You should not leave this field empty");
            }
        }

        public static void ValidateDouble(string input, string fieldName, List<string> errors)
        {
            double res;
            input = input.Replace('.', ',');
            if (!double.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out res))
            {
                errors.Add($"{fieldName} : Error converting to double");
            }
        }
    }
}
