using Souq.ViewModels;
using System.Collections.Generic;

namespace Souq.Service
{
    public interface IProductService
    {
        PagingViewModel<List<ProductViewModel>> GetProducts(int categoryId, int pageNumber=1, int pageSize=5);
        ProductViewModel GetProduct(int productId);
        void AddProduct(ProductCreateViewModel productVM);
        void RemoveProduct(int productId);
        Response<decimal> AddOffer(OfferCreateViewModel offerVM);
        IEnumerable<CategoryViewModel> GetCategories();


    }
}