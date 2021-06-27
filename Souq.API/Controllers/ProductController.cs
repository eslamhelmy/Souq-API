using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Souq.API.Middlewares;
using Souq.Service;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetProducts")]
       // [CheckToken]
        public IEnumerable<ProductViewModel> GetProducts(int? categoryId)
        {
            var products = _service.GetProducts(categoryId);

            return products;
        }

        [HttpGet]
        [Route("GetCategories")]
        // [CheckToken]
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _service.GetCategories();

        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public ProductViewModel GetProductById(int productId)
        {
            var product = _service.GetProduct(productId);

            return product;
        }


        [HttpPost]
        [Route("Add")]
        public bool AddProduct(ProductCreateViewModel productVM)
        {
            _service.AddProduct(productVM);

            return true;
        }

        [HttpPost]
        [Route("AddOffer")]
        public Response<decimal> AddOffer(OfferCreateViewModel offerVM)
        {
            return _service.AddOffer(offerVM);

        }


        [HttpDelete]
        [Route("Remove/{productId}")]
        public bool RemoveProduct(int productId)
        {
            _service.RemoveProduct(productId);

            return true;
        }
    }
}
