using Microsoft.EntityFrameworkCore;
using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Utils.Container;

namespace test_cargo_tracker_api.src.Services.Container
{
    public class ContainerService : IContainerInterface
    {
        ApplicationDbContext _context;
        private readonly ContainerValidator _containerValidator;

        public ContainerService(ApplicationDbContext context, ContainerValidator containerValidator)
        {
            _context = context;
            _containerValidator = containerValidator;
        }

        public async Task<ServiceResponse<ContainerModel>> CreateContainer(ContainerModel newContainer)
        {
            ServiceResponse<ContainerModel> serviceResponse = new ServiceResponse<ContainerModel>();

            if (!_containerValidator.IsValidContainerNumber(newContainer.ContainerNumber))
            {
                serviceResponse.Message = "The container number is invalid.";
                serviceResponse.statusCode = 400;
                serviceResponse.Success = false;
                return serviceResponse;
            }

            await _context.AddAsync(newContainer);
            await _context.SaveChangesAsync();

            serviceResponse.Data = newContainer;
            serviceResponse.Success = true;
            serviceResponse.Message = "Container created successfully";
            serviceResponse.statusCode = 201;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContainerModel>>> GetAllContainers()
        {
            ServiceResponse<List<ContainerModel>> serviceResponse = new ServiceResponse<List<ContainerModel>>();

            serviceResponse.Data = await _context.Container.ToListAsync();

            if (serviceResponse.Data.Count == 0)
            {
                serviceResponse.Message = "There are no registered container";
                serviceResponse.statusCode = 400;
                return serviceResponse;
            }

            serviceResponse.statusCode = 200;

            return serviceResponse;
        }
    }
}
