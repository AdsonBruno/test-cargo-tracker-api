using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Models.Movements;
using test_cargo_tracker_api.src.Strategies.Movements;

namespace test_cargo_tracker_api.src.Services.Movements
{
    public class ContainerMovementService : IContainerMovement
    {
        private readonly ApplicationDbContext _context;
        private readonly ContainerMovementContext _movementContext;
        
        public ContainerMovementService(ApplicationDbContext context, ContainerMovementContext movementContext)
        {
            _context = context;
            _movementContext = movementContext;
        }

        public async Task<ServiceResponse<MovementModel>> MoveContainer(MovementModel movement, IContainerMovementStrategy strategy)
        {
            _movementContext.SetStrategy(strategy);

            ServiceResponse<MovementModel> serviceResponse = await _movementContext.ExecuteMovement(movement);

            if (!serviceResponse.Success)
            {
                return serviceResponse;
            }

            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();

            serviceResponse.Data = movement;
            serviceResponse.Message = "Movement registered and saved successfully";
            serviceResponse.Success = true;
            serviceResponse.statusCode = 201;
            return serviceResponse;

        }
    }
}
