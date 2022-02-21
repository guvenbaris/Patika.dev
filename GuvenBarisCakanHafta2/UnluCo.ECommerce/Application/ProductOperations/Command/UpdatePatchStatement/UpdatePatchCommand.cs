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

        public void Handle()
        {
            var product = DataGenerator.ProductList.SingleOrDefault(p => p.ProductId == ProductId);
            //Product bulunamazsa hata fırlat.
            if (product is null)
            {
                throw new InvalidOperationException("Product didn't find.");
            }
            product.Statement = Statement;

        }
    }
}
