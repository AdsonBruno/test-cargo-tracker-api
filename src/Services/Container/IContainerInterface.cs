using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;

namespace test_cargo_tracker_api.src.Services.Container
{
    public interface IContainerInterface
    {
        Task<ServiceResponse<List<ContainerModel>>> GetAllContainers();
    }
}
