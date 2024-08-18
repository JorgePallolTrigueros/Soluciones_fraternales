using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;
using System;



namespace Ejemplo_importante.Busines
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            return customers.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone
            });
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            if (string.IsNullOrEmpty(customerDto.Email))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío.");
            }

            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };

            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var existingCustomer = _customerRepository.GetCustomerById(customerDto.CustomerId);
            if (existingCustomer == null)
            {
                throw new ArgumentException("El cliente no existe.");
            }

            existingCustomer.FirstName = customerDto.FirstName;
            existingCustomer.LastName = customerDto.LastName;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.Phone = customerDto.Phone;

            _customerRepository.UpdateCustomer(existingCustomer);
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new ArgumentException("El cliente no existe.");
            }

            _customerRepository.DeleteCustomer(customerId);
        }
    }
}