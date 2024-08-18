using Ejemplo_importante.datos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
        void AddCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
    }
}