using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Utils;
using Microsoft.EntityFrameworkCore;

namespace test_cargo_tracker_api.src.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly CpfValidator _cpfValidator;

        public CustomerService(ApplicationDbContext context, CpfValidator cpfValidator) 
        {
            _context = context;
            _cpfValidator = cpfValidator;
        }

        public async Task<ServiceResponse<CustomerModel>> CreateCustomer(CustomerModel newCustomer)
        {
            ServiceResponse<CustomerModel> serviceResponse = new ServiceResponse<CustomerModel>();

            try
            {
                if (newCustomer == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Customer data cannot be null.";
                    serviceResponse.Success = false;
                    serviceResponse.statusCode = 400;
                    return serviceResponse;
                }
                
                if (!CpfValidator.IsValid(newCustomer.cpf))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "CPF invalid!";
                    serviceResponse.statusCode = 400; 
                    return serviceResponse;
                }

                
                await _context.AddAsync(newCustomer);
                await _context.SaveChangesAsync();

                serviceResponse.Data = newCustomer;
                serviceResponse.Success = true;
                serviceResponse.Message = "Customer created successfully.";
                serviceResponse.statusCode = 201;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
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
