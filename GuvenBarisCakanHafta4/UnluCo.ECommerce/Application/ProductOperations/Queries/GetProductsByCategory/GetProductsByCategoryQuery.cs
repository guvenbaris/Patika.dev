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
        private readonly IProductRepository _productRepository;
        public int CategoryId { get; set; }
        

        public GetProductsByCategoryQuery(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public List<ProductsByCategoryModel> Handle()
        {
            var productList = _productRepository.GetAll();
            
            List<ProductsByCategoryModel> products = _mapper.Map<List<ProductsByCategoryModel>>(productList);

            return products;
        }
    }

    public class ProductsByCategoryModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}
