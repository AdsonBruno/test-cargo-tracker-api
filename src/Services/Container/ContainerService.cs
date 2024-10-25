using Microsoft.EntityFrameworkCore;
using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;

namespace test_cargo_tracker_api.src.Services.Container
{
    public class ContainerService : IContainerInterface
    {
        ApplicationDbContext _context;

        public ContainerService(ApplicationDbContext context)
        {
            _context = context;
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
