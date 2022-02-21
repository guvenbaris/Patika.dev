using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.DbOperations
{
    //Database olarak tasarlanmış static listelerimiz.
    public class DataGenerator
    {
        public static List<Product> ProductList = new List<Product>
             {

             new Product
             {
                 ProductId = 1,
                 CategoryId = 1,
                 ProductName = "Mouse",
                 UnitPrice = 100,
                 StockAmount = 50,
                 ProductAddedTime = DateTime.Now,
                 Statement = false,
             },
             new Product
             {
                 ProductId = 2,
                 CategoryId = 1,
                 ProductName = "Klavye",
                 UnitPrice = 200,
                 StockAmount = 75,
                 ProductAddedTime = DateTime.Now,
                 Statement = true,
             },
             new Product
             {
                 ProductId = 3,
                 CategoryId = 2,
                 ProductName = "Mutfak Robotu",
                 UnitPrice = 4000,
                 StockAmount = 10,
                 ProductAddedTime = new DateTime(1993,05,24),
                 Statement = false,
             },
        };

        public static List<Category> CategoryList = new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Bilgisayar",
                Description = "Bilgisayar ile alakalı teknolojik aletler"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Ev eşyaları",
                Description = "Evde kullanılabilecek teknolojik aletler"
            },
        };
        public static List<ProductQueryModel> ProductQueryModelList = new List<ProductQueryModel>();

    }
}




