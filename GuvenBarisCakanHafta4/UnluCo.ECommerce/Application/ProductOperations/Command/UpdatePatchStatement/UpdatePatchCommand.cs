using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.ECommerce.DbOperations;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.UpdatePatchStatement
{
    //Product'ın statement bilgisini güncellemek için yazılmıştır. 
    public class UpdatePatchCommand
    {
        public int ProductId { get; set; }
        public bool Statement { get; set; }
        private readonly IProductRepository _productRepository;

        public UpdatePatchCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Handle()
        {
            var product = _productRepository.GetById(ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product didn't find.");
            }
            product.Statement = Statement;

        }
    }
}
