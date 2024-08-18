using Ejemplo_importante.datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
