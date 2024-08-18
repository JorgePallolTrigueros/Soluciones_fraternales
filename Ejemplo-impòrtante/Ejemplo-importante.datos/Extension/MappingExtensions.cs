using Ejemplo_importante.datos.Entities;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_importante.datos.Extension
{
    public static class MappingExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                CustomerId = order.CustomerId,
                CustomerName = $"{order.Customer.FirstName} {order.Customer.LastName}"
            };
        }

        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }

        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                CategoryName = product.Category?.CategoryName
            };
        }

        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
    }
}