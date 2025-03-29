using System.Runtime.CompilerServices;
using WebApp.Model.DTO.Customer;

namespace WebApp.API.Services.Interface
{
    public interface ICustomerService
    {
        public Task<string> CreateCustomer(CustomerDto customer);

        public Task<bool> UpdateCustomer(CustomerDto customer);

        public Task<bool> DeleteCustomer(string id);

        public Task<CustomerDto?> GetCustomerByID(string id);

        public Task<IEnumerable<CustomerDto>> GetCustomers();
    }
}
