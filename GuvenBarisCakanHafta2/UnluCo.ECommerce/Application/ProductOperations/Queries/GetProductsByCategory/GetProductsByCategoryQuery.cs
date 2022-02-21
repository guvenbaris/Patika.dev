using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory
{
    //CategoryId ye göre Productları listelemek için yazıldı.
    public class GetProductsByCategoryQuery
    {
        private readonly IMapper _mapper;
        public int CategoryId { get; set; }

        public GetProductsByCategoryQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProductsByCategoryModel> Handle()
        {
            var productList = DataGenerator.ProductList.Where(p => p.CategoryId == CategoryId);

            //productList List<ProductsByCategoryModel> 'e maplenmiştir.
            List<ProductsByCategoryModel> products = _mapper.Map<List<ProductsByCategoryModel>>(productList);

            return products;
        }
    }

    public class ProductsByCategoryModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}
