using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.DbOperations
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> Get(Expression<Func<Product,bool>> filter);
        List<Product> GetProducts(QueryParams queryParams);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
