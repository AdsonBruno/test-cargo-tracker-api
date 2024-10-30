using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Services.Movements
{
    public interface IContainerMovement
    {
        Task<ServiceResponse<MovementModel>> MoveContainer(MovementModel movement);
    }
}
