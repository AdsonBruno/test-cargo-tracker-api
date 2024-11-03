using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Strategies.Movements
{
    public class ContainerMovementContext
    {
        private IContainerMovementStrategy _movementStrategy;

        public void SetStrategy(IContainerMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public async Task<ServiceResponse<MovementModel>> ExecuteMovement(MovementModel movement)
        {
            ServiceResponse<MovementModel> serviceResponse = new ServiceResponse<MovementModel>();

            if (_movementStrategy == null)
            {
                serviceResponse.Message = "No movement strategy defined";
                serviceResponse.Success = false;
                serviceResponse.statusCode = 400;
                return serviceResponse;
            }

            return await _movementStrategy.ExecuteMovement(movement);
        }

    }
}
