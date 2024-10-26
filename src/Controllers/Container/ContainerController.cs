using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Services.Container;

namespace test_cargo_tracker_api.src.Controllers.Container
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerInterface _containerInterface;

        public ContainerController(IContainerInterface containerInterface)
        {
            _containerInterface = containerInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContainerModel>>> CreateContainer(ContainerModel newContainer)
        {
            ServiceResponse<ContainerModel> serviceResponse = await _containerInterface.CreateContainer(newContainer);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }

            return Created("", serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<CustomerModel>>> GetAllContainers ()
        {
            ServiceResponse<List<ContainerModel>> serviceResponse = await _containerInterface.GetAllContainers();
            
            if (serviceResponse.statusCode == 400)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(await _containerInterface.GetAllContainers());
        }
    }
}
