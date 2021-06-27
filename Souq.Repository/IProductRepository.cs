using Souq.Models;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int categoryId);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Product GetProductById(int id);
        int GetProductsCount(int categoryId);
        IQueryable<Product> GetProductsAsQueryable(int categoryId);

    }
}