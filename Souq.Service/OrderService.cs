using AutoMapper;
using Microsoft.AspNetCore.Http;
using Souq.Database;
using Souq.Models;
using Souq.Repository;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Service
{
    public class OrderService: IOrderService
    {
        private readonly SouqContext _context;
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(SouqContext context, IOrderRepository repository, IProductRepository productRepository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderViewModel> GetOrders(int? userId)
        {
            var orders = _repository.GetOrders(userId).Select(x=> new OrderViewModel { 
                Id = x.ID,
                CustomerName = x.User.Email,
                ProductName = x.Product.Name,
                Price = x.Price,
                Image = x.Product.Image,
                Quantity = x.Quantity
            }).ToList();

            return orders;
        }
        public bool SetSpecialOffer(OrderOfferViewModel offerVM)
        {
           var order =  _repository.GetOrderById(offerVM.OrderId);
            order.Price = offerVM.Price;
            _context.SaveChanges();
            return true;
        }
        public void AddOrder(OrderCreateViewModel orderVM)
        {
            var product = _productRepository.GetProductById(orderVM.ProductId);

            var orderModel = _mapper.Map<Order>(orderVM);
            orderModel.Price = (product.Price - (product.Price * product.DiscountPercentage / 100)) * orderVM.Quantity;
            _repository.AddOrder(orderModel);

            _context.SaveChanges();
        }

        public void ApproveOrder(int OrderId)
        {
            var Order = _repository.GetOrderById(OrderId);
            _repository.ApproveOrder(Order);

            _context.SaveChanges();
        }
    }
}
