using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kashiash.utils
{
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }


        public static string DigitsOnly(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            Regex regexObj = new Regex(@"[^\d]", RegexOptions.Compiled);
            return regexObj.Replace(value, string.Empty);

        }

        public static string CharsAndDigitsOnly(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            //return regexObj.Replace(value, string.Empty);

        }
        
    }
}

