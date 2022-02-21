using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Extensions
{
    public static class SearchingProductExtensions
    {
        public static List<Product> SearchByName(this IQueryable<Product> products, string productName)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(productName))
            {
                return null;
            } 
            return  products.Where(p => p.ProductName.ToLower().Contains(productName.Trim().ToLower())).ToList();
        }


    }
}
