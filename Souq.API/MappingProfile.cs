using AutoMapper;
using Souq.Models;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<OrderCreateViewModel, Order>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserCreateViewModel, User>();
        }
    }
}
