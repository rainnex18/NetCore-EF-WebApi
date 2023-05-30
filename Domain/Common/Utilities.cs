using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Common
{
    public static class Utilities
    {
        public static bool isRegexValid(this string str, string pattern)
        {
            Regex reg = new Regex(pattern);

            return reg.IsMatch(str);
        }
    }

    //public static class MyExtensions {
    //    public static int RegexChecker(this string str)
    //    {
    //        return str.Split(new char[] { ' ', '.', '?' },
    //                         StringSplitOptions.RemoveEmptyEntries).Length;
    //    }
    //}
}
