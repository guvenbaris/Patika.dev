using System;
using System.Collections.Generic;

namespace UnluCo.ECommerce.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
        public bool Statement { get; set; }
        public Category Category { get; set; }

    }
}

