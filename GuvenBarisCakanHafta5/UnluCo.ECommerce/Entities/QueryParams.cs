using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.ECommerce.Entities
{
    public enum SortingDirection
    {
        Asc = 1,
        Desc
    }

    public class QueryParams
    {
        public string Search { get; set; } 
        public string Sort { get; set; } = "ProductName";
        public SortingDirection SortingDirection { get; set; }
    }
}


