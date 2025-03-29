using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Services.Implement;
using WebApp.API.Services.Interface;
using WebApp.Model.DTO.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 查詢所有客戶
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetCustomers();

            if (customers.Count() == 0)
                return NoContent();

            return Ok(customers);
        }

        /// <summary>
        /// 查詢特定客戶By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetCustomerByID(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        /// <summary>
        /// 新增客戶
        /// </summary>
        /// <param name="customer">客戶資料</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto customer)
        {
            var customerID = await _customerService.CreateCustomer(customer);

            if (customerID == null) return StatusCode(500, "新增失敗");

            return Ok(customerID);
        }

        /// <summary>
        /// 修改特定客戶By ID
        /// </summary>
        /// <param name="id">客戶ID</param>
        /// <param name="customer">客戶資料</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CustomerDto customer)
        {
            var result = await _customerService.UpdateCustomer(id, customer);

            if (!result) return StatusCode(500, "修改失敗");

            return Ok(result);
        }

        /// <summary>
        /// 刪除特定客戶By ID
        /// </summary>
        /// <param name="id">客戶ID</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _customerService.DeleteCustomer(id);

            if (!result) return StatusCode(500, "刪除失敗");

            return Ok(result);
        }
    }
}
