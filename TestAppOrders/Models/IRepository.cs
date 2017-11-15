using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOrders.Models
{
    public interface IRepository
    {
        void Save(Order o);
        IEnumerable<Order> List();
        Order Get(int id);
    }
}
