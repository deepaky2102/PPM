using System.Text.RegularExpressions;

namespace PPM.Domain
{
    public class CommonMethodClass
    {
        public static bool IsValidString(string input)
        {
            // Define a regular expression pattern for a string containing alphabets, numbers, special symbols, hyphens, and spaces between words
            string pattern = @"^[a-zA-Z0-9!@#$%^&*(),.?""':{}|<>\s\-]+$";
            // Check if the input matches the pattern
            return Regex.IsMatch(input, pattern);
        }

        public static bool IsValidEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9]+(\.[a-zA-Z0-9]+)*\.?[a-zA-Z0-9]*@[a-zA-Z0-9]+\.(com|ac\.in|COM|AC\.IN)$";
            return Regex.IsMatch(input, pattern);
        }

        public static bool IsValidMobileNumber(string input)
        {
            string pattern = @"^[0-9]{10}$";
            return Regex.IsMatch(input, pattern);
        }

        protected CommonMethodClass()
        { }
    }
}