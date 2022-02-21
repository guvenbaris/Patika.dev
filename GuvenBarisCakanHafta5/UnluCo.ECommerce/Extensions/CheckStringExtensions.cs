using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.ECommerce.Extensions
{

    //String 'e yazılan extension.
    public static class CheckStringExtensions
    {
        public static bool IsNull(this string str)
        {
            
            return string.IsNullOrEmpty(str);
        }
    }
}
