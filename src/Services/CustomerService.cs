using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;

namespace test_cargo_tracker_api.src.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CustomerModel>>> GetCustomer()
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = new ServiceResponse<List<CustomerModel>>();

            try
            {
                serviceResponse.Date = _context.Customer.ToList();

                if (serviceResponse.Date.Count == 0)
                {
                    serviceResponse.Message = "Não há clientes cadastrados";
                }
            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
