using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.datos.Entities;
using Ejemplo_importante.datos.Interfaces;
using System.Data.Entity; // Agrega esta línea para incluir el namespace correcto

namespace Ejemplo_importante.datos.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            // Incluir Customer al obtener Orders
            return _context.Orders.Include(o => o.Customer).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            // Incluir Customer al obtener una Order por ID
            return _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.OrderId == orderId);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}