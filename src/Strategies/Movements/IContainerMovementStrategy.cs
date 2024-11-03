using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Strategies.Movements
{
    public interface IContainerMovementStrategy
    {
        Task<ServiceResponse<MovementModel>> ExecuteMovement(MovementModel movement);
    }
}
