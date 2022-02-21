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

        public void Handle()
        {
            var product = DataGenerator.ProductList.SingleOrDefault(p => p.ProductId == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product didn't find");
            }

            DataGenerator.ProductList.Remove(product);
        }

    }
}
