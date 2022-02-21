using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Services.Business
{

    // Fake servis olarak yazılmıştır. Injection yapılabilmesi için ProductControllera.
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
    }
}
