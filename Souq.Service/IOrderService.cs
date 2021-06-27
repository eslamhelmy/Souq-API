using Souq.ViewModels;
using System.Collections.Generic;

namespace Souq.Service
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetOrders(int? userId);
        void AddOrder(OrderCreateViewModel OrderVM);
        void ApproveOrder(int OrderId);
        bool SetSpecialOffer(OrderOfferViewModel offerVM);

    }
}