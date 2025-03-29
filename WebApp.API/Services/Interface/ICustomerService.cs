using System.Runtime.CompilerServices;
using WebApp.Model.DTO.Customer;

namespace WebApp.API.Services.Interface
{
    public interface ICustomerService
    {
        public Task<int> CreateCustomer(CustomerDto customer);

        public Task<bool> UpdateCustomer(CustomerDto customer);

        public Task<bool> DeleteCustomer(int id);

        public Task<CustomerDto?> GetCustomerByID(int id);

        public Task<IEnumerable<CustomerDto>> GetCustomers();
    }
}
