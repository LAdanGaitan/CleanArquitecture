using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rentals.Events
{
	public sealed record CancelledRentDomainEvent(Guid RentId):IDomainEvent;
	
}
