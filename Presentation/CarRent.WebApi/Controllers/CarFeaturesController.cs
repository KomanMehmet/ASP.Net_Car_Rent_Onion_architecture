using CarRent.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarRent.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));

            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvaliableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvaliableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));

            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("CarFeatureChangeAvaliableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvaliableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));

            return Ok("Güncelleme Yapıldı");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            _mediator.Send(createCarFeatureByCarCommand);

            return Ok("Ekleme Yapıldı");
        }
    }
}
