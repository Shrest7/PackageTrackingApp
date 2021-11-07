using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PackageTrackingApp.Extensions
{
    public static class StringExtensions
    {
        private static Regex EmailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*
            @(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        private static Regex PhoneNumberRegex = new Regex(@"^(\+[0-9]{9})$");

        public static bool IsEmail(this string email)
            => EmailRegex.IsMatch(email);

        public static bool IsPhoneNumber(this string number)
            => PhoneNumberRegex.IsMatch(number);
    }
}
