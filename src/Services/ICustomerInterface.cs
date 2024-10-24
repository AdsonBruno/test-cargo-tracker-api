using test_cargo_tracker_api.src.Models;

namespace test_cargo_tracker_api.src.Services
{
    public interface ICustomerInterface
    {
        Task<ServiceResponse<CustomerModel>> CreateCustomer(CustomerModel newCustomer);
        Task<ServiceResponse<List<CustomerModel>>> GetCustomer();
    }
}
