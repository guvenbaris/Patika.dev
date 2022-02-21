using System;
using System.Collections.Generic;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Services.Business
{
    // Fake servis olarak yazılmıştır. Injection yapılabilmesi için ProductController a.
    //Herhangi bir görevi yoktur. Boş Manager.
    public class ProductManager : IProductService
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
