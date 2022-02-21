using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UnluCo.ECommerce.Extensions
{
    public static class TextCheckForEmpty
    {
        public static string CheckEmptyAndCapitalize(this string str)
        {
            var result =   char.ToUpper(str[0]) + str.Substring(1).ToLower();
            return result.Trim();
        }

    }
}
