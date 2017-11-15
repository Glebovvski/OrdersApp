using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

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
            if (order == null)
            {
                throw new NullReferenceException();
            }
            else return order;
        }

        public void Edit(Order o)
        {
            context.Entry(o).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public void Create(Order o)
        {
            Order order = new Order()
            {
                Number = o.Number,
                CreateDate = o.CreateDate,
                EndDate = o.EndDate,
                Manager = o.Manager,
                Annotation = o.Annotation
            };
            context.Orders.Add(order);
            context.SaveChangesAsync();
        }
    }
}