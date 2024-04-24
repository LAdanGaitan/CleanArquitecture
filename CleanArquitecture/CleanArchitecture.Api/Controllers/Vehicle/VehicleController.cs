using CleanArchitecture.Application.Vehicles.SearchVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Vehicle
{
    [ApiController]
    [Route("api/Controller")]
    public class VehicleController : ControllerBase
    {
        private readonly ISender _sender;

        public VehicleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SerachVehicles(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var query = new SearchVehiclesQuery(startDate, endDate);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }
    }
}
