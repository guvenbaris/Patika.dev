using System;
using System.Linq;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct
{
    //ProductController dan yapılan post işlemi tamamlamak için yazılmıştır.
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductCommand(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void Handle()
        {
            var product = _productRepository.Get(p => p.ProductName == Model.ProductName).FirstOrDefault();
            if (product is not null)
            {
                throw new InvalidOperationException("This product has been created before.");
            }
            product = _mapper.Map<Product>(Model);
            product.Statement = true;
            product.ProductAddedTime = DateTime.Now;
            _productRepository.Add(product);
        }
    }

    public class CreateProductModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
