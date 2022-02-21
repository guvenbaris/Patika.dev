using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.ECommerce.DbOperations;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.DeleteProduct
{
    //Product Delete işlemi yapılmıştır.
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }

        private readonly IProductRepository _productRepository;

        public DeleteProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle()
        {
            var product = _productRepository.GetById(ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product didn't find");
            }
            _productRepository.Delete(ProductId);
        }

    }
}
