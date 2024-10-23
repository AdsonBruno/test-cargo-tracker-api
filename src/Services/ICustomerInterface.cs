using test_cargo_tracker_api.src.Models;

namespace test_cargo_tracker_api.src.Services
{
    public interface ICustomerInterface
    {

        Task<ServiceResponse<List<CustomerModel>>> GetCustomer();
    }
}
