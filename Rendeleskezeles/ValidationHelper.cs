using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rendeleskezeles
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidAddress(string address)
        {
            var pattern = @"^[\p{L} ]+\s\d+,\s[\p{L} ]+,\s[\p{L} ]+,\s\d{4}$";
            return Regex.IsMatch(address, pattern);
        }

        public static bool IsValidOrderDate(DateTime orderDate)
        {
            return orderDate.Date <= DateTime.Now.Date;
        }
    }

}
