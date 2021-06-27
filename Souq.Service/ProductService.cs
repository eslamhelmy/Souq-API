using AutoMapper;
using Souq.Database;
using Souq.Models;
using Souq.Repository;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Service
{
    public class ProductService: IProductService
    {
        private readonly SouqContext _context;
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly int pageSize = 5;

        public ProductService(SouqContext context, IProductRepository repository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public PagingViewModel<List<ProductViewModel>> GetProducts(int? categoryId, int pageNumber=1)
        {
            var count = _repository.GetProductsCount(categoryId);
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            var currentPage = pageNumber;

            var products = _repository.GetProductsAsQueryable(categoryId)
                                .Skip((pageNumber - 1)* pageSize )
                                .Take(pageSize)
                                .ToList();

            var viewModels = _mapper.Map<List<ProductViewModel>>(products);
            viewModels.ToList().ForEach(x => {
                x.NewPrice = x.Price - (x.Price * x.DiscountPercentage / 100);
            });

            return new PagingViewModel<List<ProductViewModel>>
            {
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                items = viewModels,
                totalItems = count
            };
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var categories = _categoryRepository.GetCategorys();
            var viewModels = _mapper.Map<List<CategoryViewModel>>(categories);
            
            return viewModels;
        }

        public ProductViewModel GetProduct(int productId)
        {
           var product =  _repository.GetProductById(productId);
           
            var viewModel = _mapper.Map<ProductViewModel>(product);
            viewModel.NewPrice = product.Price - (product.Price * product.DiscountPercentage / 100);

            return viewModel;
        }

        public void AddProduct(ProductCreateViewModel productVM)
        {
            var productModel = _mapper.Map<Product>(productVM);
            _repository.AddProduct(productModel);

            _context.SaveChanges();
        }

        public Response<decimal> AddOffer(OfferCreateViewModel offerVM)
        {
            var product = _repository.GetProductById(offerVM.ProductId);
            product.DiscountPercentage = offerVM.Percentage;
            _context.SaveChanges();
            return new SuccessResponse<decimal>(product.Price - (product.DiscountPercentage*product.Price/100));
        }

        public void RemoveProduct(int productId)
        {
            var product = _repository.GetProductById(productId);
            _repository.RemoveProduct(product);

            _context.SaveChanges();
        }
    }
}
