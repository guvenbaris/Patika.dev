using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UnluCo.ECommerce.DataAccess;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.DbOperations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.Include(c=>c.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(c => c.Category).SingleOrDefault(p => p.ProductId == id);
        }

        public List<Product> Get(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.Where(filter).ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product =  GetById(id);
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
