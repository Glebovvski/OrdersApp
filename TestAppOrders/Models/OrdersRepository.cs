using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace TestAppOrders.Models
{
    public class OrdersRepository : IRepository
    {
        private OrderContext context = new OrderContext();

        public void Save(Order order)
        {
            if (order == null)
            {
                throw new NullReferenceException();
            }
            context.Orders.Add(order);
            context.SaveChangesAsync();
        }

        public IEnumerable<Order> List()
        {
            return context.Orders.ToList();
        }

        public Order Get(int id)
        {
            var order = context.Orders.Find(id);
            return order;
        }
    }
}