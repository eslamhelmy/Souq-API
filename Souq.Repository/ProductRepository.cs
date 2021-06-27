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

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return
                 _dbset.Where(x => categoryId == -1 || x.CategoryID == categoryId).ToList();
        }

        public IQueryable<Product> GetProductsAsQueryable(int categoryId)
        {
            return
                 _dbset.Where(x => categoryId == -1 || x.CategoryID == categoryId);
        }
        public int GetProductsCount(int categoryId)
        {
            return
                 _dbset.Where(x => categoryId == -1 || x.CategoryID == categoryId).Count();
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
