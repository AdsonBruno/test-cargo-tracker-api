using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Strategies.Movements
{
    public class GateInContainerStrategy : IContainerMovementStrategy
    {
        public async Task<ServiceResponse<MovementModel>> ExecuteMovement(MovementModel movement)
        {
            ServiceResponse<MovementModel> serviceResponse = new ServiceResponse<MovementModel>();

            serviceResponse.Data = movement;
            serviceResponse.Message = "Container gate in successfully";
            serviceResponse.statusCode = 200;
            serviceResponse.Success = true;
            return serviceResponse;
        }
    }
}
