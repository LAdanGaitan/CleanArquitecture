namespace CleanArchitecture.Api.Controllers.Rent
{
	public sealed record BookRentRequest(Guid VehicleId,Guid UserId,DateOnly StartDate, DateOnly EndDate);

}
