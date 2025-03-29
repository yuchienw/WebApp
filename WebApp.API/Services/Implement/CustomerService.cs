using Mapster;
using WebApp.Access.Entity;
using WebApp.Access.Infrastructure.Interface;
using WebApp.API.Services.Interface;
using WebApp.Model.DTO.Customer;

namespace WebApp.API.Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                Customer customer = customerDto.Adapt<Customer>();
                using (var uow = _unitOfWork)
                {
                    var res = await uow.CustomerRepo.AddAsync(customer);
                    uow.SaveChanges();
                    return res.ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDto?> GetCustomerByID(string id)
        {
            try
            {
                using (var uow = _unitOfWork)
                {
                    Customer? customer = await uow.CustomerRepo.FindAsync(id);
                    return customer.Adapt<CustomerDto>();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
