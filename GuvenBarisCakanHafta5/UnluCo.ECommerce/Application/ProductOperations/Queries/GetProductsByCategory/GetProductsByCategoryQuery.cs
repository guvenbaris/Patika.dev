using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory
{
    //CategoryId ye göre Productları listelemek için yazıldı.
    public class GetProductsByCategoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memoryCache;
        public int CategoryId { get; set; }
        

        public GetProductsByCategoryQuery(IMapper mapper, IProductRepository productRepository, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _memoryCache = memoryCache;
        }

        public List<ProductsByCategoryModel> Handle()
        {
            var cacheKey = "productByCategoryId";

            if (!_memoryCache.TryGetValue(cacheKey, out List<Product> products))
            {
                products = _productRepository.Get(p => p.CategoryId == CategoryId);

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                _memoryCache.Set(cacheKey, products, cacheExpiryOptions);
            }

            return _mapper.Map<List<ProductsByCategoryModel>>(products);
        }
    }

    public class ProductsByCategoryModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
}
