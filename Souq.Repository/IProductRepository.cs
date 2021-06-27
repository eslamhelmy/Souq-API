using Souq.Models;
using System.Collections.Generic;

namespace Souq.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int? categoryId);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Product GetProductById(int id);

    }
}