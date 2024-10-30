using Microsoft.AspNetCore.Mvc;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Models.Movements;
using test_cargo_tracker_api.src.Services.Movements;

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

            ServiceResponse<MovementModel> serviceResponse = await _containerMovementService.MoveContainer(movement);


            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }

            await _containerMovementService.MoveContainer(movement);

            return Created("", serviceResponse);
        }
    }
}
