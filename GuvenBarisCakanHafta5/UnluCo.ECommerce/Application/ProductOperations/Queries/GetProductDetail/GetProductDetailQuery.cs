using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail
{
    //ProductId ye göre tek bir Product getirmek için yazılmıştır.
    public class GetProductDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public int ProductId { get; set; }
        private readonly IProductRepository _productRepository;

        public GetProductDetailQuery(IMapper mapper, IProductRepository productRepository, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _memoryCache = memoryCache;
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

