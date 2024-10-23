using Microsoft.AspNetCore.Mvc;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Services;

namespace test_cargo_tracker_api.src.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerInterface;
        public CustomerController(ICustomerInterface customerInterface)
        {
            _customerInterface = customerInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> GetCustomer()
        {
            return Ok(await _customerInterface.GetCustomer());
        }
    }
}
