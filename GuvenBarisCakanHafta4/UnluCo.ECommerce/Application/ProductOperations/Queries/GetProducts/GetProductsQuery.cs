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
        private readonly IProductRepository _productRepository;
        public GetProductsQuery(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public List<ProductQueryModel> Handle()
        {
            var productList = _productRepository.GetAll();

            return _mapper.Map<List<ProductQueryModel>>(productList);
        }

    }
    //Productların gösterilmesini istediğimiz modelimiz.
    public class ProductQueryModel
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}

