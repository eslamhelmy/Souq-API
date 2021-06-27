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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetOrders")]
      //  [CheckToken]
        public IEnumerable<OrderViewModel> GetOrders(int? userId)
        {
            var Orders = _service.GetOrders(userId);

            return Orders;
        }

        [HttpPost]
        [CheckToken]
        [Route("Add")]
        public bool AddOrder(OrderCreateViewModel OrderVM)
        {
                OrderVM.UserId = ((UserViewModel)HttpContext.Items["User"]).ID;
                _service.AddOrder(OrderVM);
                return true;
        }

        [HttpPost]
        [Route("SetSpecialOffer")]
        public bool SetSpecialOffer(OrderOfferViewModel offerVM)
        {
            return _service.SetSpecialOffer(offerVM);
        }

        
        [HttpDelete]
        [Route("Remove/{orderId}")]
        public bool ApproveOrder(int orderId)
        {
            _service.ApproveOrder(orderId);

            return true;
        }
    }
}
