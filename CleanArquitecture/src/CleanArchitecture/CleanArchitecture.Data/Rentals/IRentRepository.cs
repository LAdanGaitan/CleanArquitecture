using CleanArchitecture.Data.Vehicles;

namespace CleanArchitecture.Domain.Rentals
{
	internal interface IRentRepository
	{
		Task<Rent?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
		Task<bool> IsOverlappingAsync(Vehicle vehicle,DateRange term, CancellationToken cancellationToken = default);
		void Add(Rent rent);
	}
}
