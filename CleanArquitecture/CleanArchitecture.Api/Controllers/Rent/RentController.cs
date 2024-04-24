using CleanArchitecture.Application.Rents.BookRental;
using CleanArchitecture.Application.Rents.GetRent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Rent
{
	[ApiController]
	[Route("api/Rent")]
	public class RentController : ControllerBase
	{
		private readonly ISender _sender;

		public RentController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRent(Guid id,CancellationToken cancellationToken)
		{
			var query = new GetRentQuery(id);
			var result = await _sender.Send(query,cancellationToken);

			return result.IsSuccess ? Ok(result.Value): NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> BookRental(Guid id, BookRentRequest request,CancellationToken cancellationToken)
		{
			var command = new BookRentalCommand(request.VehicleId,request.UserId,request.StartDate,request.EndDate);

			var response = await _sender.Send(command,cancellationToken);

			if (response.IsFailure)
			{
				return BadRequest(response.Error);
			}

			return CreatedAtAction(nameof(GetRent), new {id = response.Value});

		}

	}
}
