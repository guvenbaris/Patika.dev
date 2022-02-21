using System;
using System.Linq;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail
{
    //ProductId ye göre tek bir Product getirmek için yazılmıştır.
    public class GetProductDetailQuery
    {
        private readonly IMapper _mapper;

        public int ProductId { get; set; }
        private readonly IProductRepository _productRepository;

        public GetProductDetailQuery(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ProductDetailQueryModel Handle()
        {
            var product = _productRepository.GetById(ProductId);
           
            if (product is null)
            {
                throw new InvalidOperationException("Product did not found");
            }

            return _mapper.Map<ProductDetailQueryModel>(product);
        }

    }

    public class ProductDetailQueryModel
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
   
}

