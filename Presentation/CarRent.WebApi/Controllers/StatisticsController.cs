using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());

            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());

            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());

            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());

            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());

            return Ok(values);
        }

        [HttpGet("GetAvarageRentPriceToDaily")]
        public async Task<IActionResult> GetAvarageRentPriceToDaily()
        {
            var values = await _mediator.Send(new GetAvarageRentPriceToDailyQuery());

            return Ok(values);
        }

        [HttpGet("GetAvarageRentPriceToWeekly")]
        public async Task<IActionResult> GetAvarageRentPriceToWeekly()
        {
            var values = await _mediator.Send(new GetAvarageRentPriceToWeeklyQuery());

            return Ok(values);
        }

        [HttpGet("GetAvarageRentPriceToMountly")]
        public async Task<IActionResult> GetAvarageRentPriceToMountly()
        {
            var values = await _mediator.Send(new GetAvarageRentPriceToMountlyQuery());

            return Ok(values);
        }

        [HttpGet("GetCarCountByTransmisionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmisionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmisionIsAutoQuery());

            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());

            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());

            return Ok(values);
        }

        [HttpGet("GetCarCountByKmLessThan1000")]
        public async Task<IActionResult> GetCarCountByKmLessThan1000()
        {
            var values = await _mediator.Send(new GetCarCountByKmLessThan1000Query());

            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFuelGasOrDieselQuery());

            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());

            return Ok(values);
        }

        [HttpGet("GetBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetBrandAndModelByRentPriceDailyMax()
        {
            var values = await _mediator.Send(new GetBrandAndModelByRentPriceDailyMaxQuery());

            return Ok(values);
        }

        [HttpGet("GetBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetBrandAndModelByRentPriceDailyMin()
        {
            var values = await _mediator.Send(new GetBrandAndModelByRentPriceDailyMinQuery());

            return Ok(values);
        }
    }
}
