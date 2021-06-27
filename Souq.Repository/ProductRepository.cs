using Microsoft.EntityFrameworkCore;
using Souq.Database;
using Souq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<Product> _dbset;
        public ProductRepository(SouqContext context)
        {
            _dbset = context.Set<Product>();
        }

        public IEnumerable<Product> GetProducts(int? categoryId)
        {
            return
                 _dbset.Where(x => categoryId == null || x.CategoryID == categoryId).ToList();
        }

        public Product GetProductById(int id)
        {
            return
                 _dbset.Where(x => x.ID == id).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _dbset.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _dbset.Remove(product);
        }

    }
}
