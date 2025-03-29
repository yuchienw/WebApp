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

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            try
            {
                using (var uow = _unitOfWork)
                {
                    List<Customer> customer = (await uow.CustomerRepo.FindAllAsync()).ToList();
                    return customer.Adapt<IEnumerable<CustomerDto>>();
                }
            }
            catch
            {
                throw;
            }
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

        public async Task<string?> CreateCustomer(CustomerDto dto)
        {
            try
            {
                Customer customer = dto.Adapt<Customer>();
                using (var uow = _unitOfWork)
                {
                    var res = await uow.CustomerRepo.AddAsync(customer);

                    uow.SaveChanges();

                    if (res != null)
                        return res.ToString();

                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateCustomer(string id, CustomerDto dto)
        {
            try
            {
                using (var uow = _unitOfWork)
                {
                    Customer customer = await uow.CustomerRepo.FindAsync(id);

                    if (customer == null) return false;
                    
                    customer.CompanyName = dto.CompanyName;
                    customer.ContactName = dto.ContactName;
                    customer.ContactTitle = dto.ContactTitle;
                    customer.Address = dto.Address;
                    customer.City = dto.City;
                    customer.Region = dto.Region;
                    customer.PostalCode = dto.PostalCode;
                    customer.Country = dto.Country;
                    customer.Phone = dto.Phone;
                    customer.Fax = dto.Fax;

                    var isSuccess = await uow.CustomerRepo.UpdateAsync(customer);

                    uow.SaveChanges();

                    return isSuccess;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            try
            {
                using (var uow = _unitOfWork)
                {
                    var isSuccess = await uow.CustomerRepo.DeleteAsync(id);

                    uow.SaveChanges();

                    return isSuccess;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
