using CarRent.Application.Features.Mediator.Commands.TestimonialCommands;
using CarRent.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRent.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarPricingWithCarList()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarQuery());

			return Ok(values);
		}

		
	}
}
