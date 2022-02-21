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

        public GetProductDetailQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDetailQueryModel Handle()
        {
            var product = DataGenerator.ProductList.SingleOrDefault(p => p.ProductId == ProductId);
           
            if (product is null)
            {
                throw new InvalidOperationException("Product did not found");
            }
            var category = DataGenerator.CategoryList.SingleOrDefault(c => c.CategoryId == product.CategoryId);

            ProductDetailQueryModel productDetail = new ProductDetailQueryModel();
            if (product.CategoryId == category?.CategoryId)
            {
                ProductDetailQueryModel _productDetail = new ProductDetailQueryModel
                {
                    Category = category.CategoryName,
                    ProductAddedTime = product.ProductAddedTime,
                    ProductName = product.ProductName,
                    StockAmount = product.StockAmount,
                    UnitPrice = product.UnitPrice
                };
                productDetail =  _productDetail;
            }

            return productDetail;
        }

    }

    public class ProductDetailQueryModel
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public DateTime ProductAddedTime { get; set; }
    }
   
}

