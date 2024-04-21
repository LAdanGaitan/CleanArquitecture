using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Rents.BookRental
{
	public record BookRentalCommand(Guid VehicleId,Guid UserId,DateOnly InitDate,DateOnly EndDate):ICommand<Guid>;
	
}
