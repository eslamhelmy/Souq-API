using Souq.Models;
using System.Collections.Generic;

namespace Souq.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders(int? userId);
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void ApproveOrder(Order order);
    }
}