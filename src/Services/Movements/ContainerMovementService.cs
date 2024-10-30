using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Services.Movements
{
    public class ContainerMovementService : IContainerMovement
    {
        private readonly ApplicationDbContext _context;
        
        public ContainerMovementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<MovementModel>> MoveContainer(MovementModel movement)
        {
            ServiceResponse<MovementModel> serviceResponse = new ServiceResponse<MovementModel>();
            
            ContainerModel container = await _context.Container.FindAsync(movement.ContainerId);

            if (container == null)
            {
                serviceResponse.Message = "Container not found";
                serviceResponse.Success = false;
                serviceResponse.statusCode = 404;

                return serviceResponse;
            }

            MovementModel newMovement = new MovementModel
            {
                ContainerId = movement.ContainerId,
                Type = movement.Type,
                StartDateTime = movement.StartDateTime,
                EndDateTime = movement.EndDateTime,
            };

            await _context.Movements.AddAsync(newMovement);
            await _context.SaveChangesAsync();

            serviceResponse.Data = newMovement;
            serviceResponse.Message = "Movement registered successfully";
            serviceResponse.statusCode = 201;

            return serviceResponse;
        }

    }
}
