using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;
using System;

using Ejemplo_importante.datos.Extension; // Asegúrate de incluir esto

namespace Ejemplo_importante.Busines
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return orders.Select(o => o.ToDto());
        }

        public OrderDto GetOrderById(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            return order?.ToDto();
        }

        public void AddOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                TotalAmount = orderDto.TotalAmount,
                CustomerId = orderDto.CustomerId
            };

            _orderRepository.AddOrder(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var order = _orderRepository.GetOrderById(orderDto.OrderId);
            if (order == null)
            {
                throw new ArgumentException("La orden no existe.");
            }

            order.OrderDate = orderDto.OrderDate;
            order.TotalAmount = orderDto.TotalAmount;
            order.CustomerId = orderDto.CustomerId;

            _orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }
    }
}