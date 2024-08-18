using Ejemplo_importante.datos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int orderId);
        void AddOrder(OrderDto order);
        void UpdateOrder(OrderDto order);
        void DeleteOrder(int orderId);
    }
}
