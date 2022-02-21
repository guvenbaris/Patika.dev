using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;


namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts
{
    // Bütün productları listelemek için yazılmıştır.
    public class GetProductsQuery
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;

        public GetProductsQuery(IMapper mapper, IProductRepository productRepository, IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _distributedCache = distributedCache;
        }

        public List<ProductQueryModel> Handle()
        {
            var cacheKey = "productlist";

            var redisProductList = _distributedCache.Get(cacheKey);

            if (redisProductList is not null)
            {
                var productListFromCache =  JsonConvert.DeserializeObject<List<Product>>(Encoding.UTF8.GetString(redisProductList));
                return _mapper.Map<List<ProductQueryModel>>(productListFromCache);
            }

            var productListFromDb = _productRepository.GetAll();
            redisProductList = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(productListFromDb));
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            _distributedCache.Set(cacheKey, redisProductList, options);
            return _mapper.Map<List<ProductQueryModel>>(productListFromDb);
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

