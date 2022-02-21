using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly int _productId;
        public CreateProductCommand(IMapper mapper)
        {
            _mapper = mapper;
            _productId  =  DataGenerator.ProductList.Count;
            _productId++;
        }

        public void Handle()
        {
            var product = DataGenerator.ProductList.SingleOrDefault(x => x.ProductName == Model.ProductName);
            if (product is not null)
            {
                throw new InvalidOperationException("This product has been created before.");
            }

            product = _mapper.Map<Product>(Model);
            product.ProductId = _productId;
            product.Statement = true;
            product.ProductAddedTime = DateTime.Now;
            DataGenerator.ProductList.Add(product);
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
