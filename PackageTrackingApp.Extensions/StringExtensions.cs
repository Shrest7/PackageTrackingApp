using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PackageTrackingApp.Extensions
{
    public static class StringExtensions
    {
        private static Regex PhoneNumberRegex = new Regex(@"^([0-9]{9})$");
        private static Regex containsUpperChar = new Regex(@"[A-Z]+");

        public static bool IsEmail(this string email)
            => email != null && new EmailAddressAttribute().IsValid(email);

        public static bool IsValidPassword(this string password)
            => containsUpperChar.IsMatch(password);

        public static bool IsPhoneNumber(this string number)
            => PhoneNumberRegex.IsMatch(number);

        public static string FirstCharToUpper(this string input) 
            => input switch
            {
                null => throw new ArgumentNullException($"{nameof(input)} can not be null."),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty"),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }
}
