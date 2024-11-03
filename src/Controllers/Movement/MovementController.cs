using Microsoft.AspNetCore.Mvc;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Models.Movements;
using test_cargo_tracker_api.src.Services.Movements;
using test_cargo_tracker_api.src.Strategies.Movements;

namespace test_cargo_tracker_api.src.Controllers.Movement
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IContainerMovement _containerMovementService;

        public MovementController(IContainerMovement containerMovementService)
        {
            _containerMovementService = containerMovementService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<MovementModel>>> MovementContainer(MovementModel movement)
        {
            IContainerMovementStrategy strategy;

            if (movement.Type == "gate in")
            {
                strategy = new GateInContainerStrategy();

            } 
            else
            {
                strategy = null;
            }

            if (strategy == null)
            {
                return BadRequest(new ServiceResponse<MovementModel> 
                { 
                    Message = "Invalid movement type.",
                    statusCode = 400,
                    Success = false
                });
            }

            ServiceResponse<MovementModel> serviceResponse = await _containerMovementService.MoveContainer(movement, strategy);

            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }

            return Created("", serviceResponse);
        }
    }
}
