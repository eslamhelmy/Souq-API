using Souq.ViewModels;
using System.Collections.Generic;

namespace Souq.Service
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts(int? categoryId);
        ProductViewModel GetProduct(int productId);
        void AddProduct(ProductCreateViewModel productVM);
        void RemoveProduct(int productId);
        Response<decimal> AddOffer(OfferCreateViewModel offerVM);
        IEnumerable<CategoryViewModel> GetCategories();


    }
}