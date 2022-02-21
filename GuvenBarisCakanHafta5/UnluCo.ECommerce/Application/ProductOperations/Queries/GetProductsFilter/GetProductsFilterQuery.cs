using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsFilter
{
    public class GetProductsFilterQuery
    {
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly IProductRepository _productRepository;

        public QueryParams Params { get; set; }
        public GetProductsFilterQuery(IMapper mapper, IDistributedCache distributedCache, IProductRepository productRepository)
        {
            _mapper = mapper;
            _distributedCache = distributedCache;
            _productRepository = productRepository;
        }

        public List<ProductFilterModel> Handle()
        {
            var cacheKey = "productFilter";
            var redisProductFilterList = _distributedCache.Get(cacheKey);

            if (CheckCacheDataAndHour(redisProductFilterList))
            {
                var productListFromCache =
                    JsonConvert.DeserializeObject<List<Product>>(Encoding.UTF8.GetString(redisProductFilterList));
                return _mapper.Map<List<ProductFilterModel>>(productListFromCache);
            }

            var productListFromDb = _productRepository.GetProducts(queryParams: Params);

            if (CheckProductListCacheCondition(productListFromDb))
            {
                redisProductFilterList = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(productListFromDb));
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                _distributedCache.Set(cacheKey, redisProductFilterList, options);
            }

            return _mapper.Map<List<ProductFilterModel>>(productListFromDb);
        }

        private static bool CheckProductListCacheCondition(List<Product> products) => 
            products.Count > 100 & DateTime.Now.Hour == 00;

        private static bool CheckCacheDataAndHour(byte[] productBytes) =>
            productBytes is not null & DateTime.Now.Hour == 00;


    }
    public class ProductFilterModel
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}
