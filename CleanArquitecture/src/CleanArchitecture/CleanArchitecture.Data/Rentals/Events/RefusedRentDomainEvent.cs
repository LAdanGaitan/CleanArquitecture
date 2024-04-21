using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rentals.Events
{
	public sealed record RefusedRentDomainEvent(Guid RentId):IDomainEvent;
	
}
