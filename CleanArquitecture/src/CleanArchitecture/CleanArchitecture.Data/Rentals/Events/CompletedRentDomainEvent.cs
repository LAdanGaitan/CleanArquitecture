using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rentals.Events
{
	public sealed record CompletedRentDomainEvent(Guid RentId):IDomainEvent;
	
}
