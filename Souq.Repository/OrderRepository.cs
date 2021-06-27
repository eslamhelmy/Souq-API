using Microsoft.EntityFrameworkCore;
using Souq.Database;
using Souq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DbSet<Order> _dbset;
        public OrderRepository(SouqContext context)
        {
            _dbset = context.Set<Order>();
        }

        public IEnumerable<Order> GetOrders(int? userId)
        {
            return
                 _dbset.Where(x => userId == null || x.UserID == userId)
                        .Include(x=> x.User)
                        .Include(x=> x.Product)
                        .ToList();
        }

        public Order GetOrderById(int id)
        {
            return
                 _dbset.Where(x => x.ID == id).FirstOrDefault();
        }

        public void AddOrder(Order order)
        {
            _dbset.Add(order);
        }

        public void ApproveOrder(Order order)
        {
            _dbset.Update(order);
        }

    }
}
