using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Rentals;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
	internal sealed class RentRepository : Repository<Rent>, IRentRepository
	{
		private static readonly RentStatus[] ActiveRentSatuses =
		{
			RentStatus.Reserved,
			RentStatus.Confimed,
			RentStatus.Complete
		};
		public RentRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<bool> IsOverlappingAsync(Vehicle vehicle, DateRange term, CancellationToken cancellationToken = default)
		{
			return await DbContext.Set<Rent>().AnyAsync(rent => rent.VehicleId == vehicle.Id && rent.Term!.Init <= term.End && rent.Term.End >= term.Init && ActiveRentSatuses.Contains(rent.Status),cancellationToken);
		}
	}
}
