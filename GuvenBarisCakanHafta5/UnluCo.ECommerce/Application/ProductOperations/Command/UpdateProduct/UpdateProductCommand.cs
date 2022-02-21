using System;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;
using UnluCo.ECommerce.Extensions;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct
{
    //Product Update işlemi için yazılmıştır.
    public class UpdateProductCommand
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductModel Model { get; set; }
        public int ProductId { get; set; }

        public UpdateProductCommand(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void Handle()
        {
            var product = _productRepository.GetById(ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product has not been in exist");
            }
            _productRepository.Update(_mapper.Map<Product>(Model));
        }
    }

    //Map edilecek Model tanımlanmıştır.
    public class UpdateProductModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
