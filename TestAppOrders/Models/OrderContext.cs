using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestAppOrders.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext")
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}