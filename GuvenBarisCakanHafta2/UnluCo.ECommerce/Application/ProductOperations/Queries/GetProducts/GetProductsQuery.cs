using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;


namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts
{
    // Bütün productları listelemek için yazılmıştır.
    public class GetProductsQuery
    {
        private readonly IMapper _mapper;

        public GetProductsQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProductQueryModel> Handle()
        {
            var productList = DataGenerator.ProductList.OrderBy(x => x.ProductId);

            //CategoryId yerine CategoryName yazılmasını istediğimiz için manuel olarak map ettik. 
            //EntityFramework de omatik olarak map edilebiliyor. 

            foreach (var product in productList)
            {
                var category = DataGenerator.CategoryList.SingleOrDefault(c => c.CategoryId == product.CategoryId);

                ProductQueryModel query = new ProductQueryModel
                {
                    Category = category?.CategoryName,
                    ProductAddedTime = product.ProductAddedTime,
                    ProductName = product.ProductName,
                    StockAmount = product.StockAmount,
                    UnitPrice = product.UnitPrice
                };
                DataGenerator.ProductQueryModelList.Add(query);
            }

            return DataGenerator.ProductQueryModelList;
        }

    }
    //Productların gösterilmesini istediğimi modelimiz.
    public class ProductQueryModel
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}

