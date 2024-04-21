using CleanArchitecture.Data.Vehicles;

namespace CleanArchitecture.Domain.Rentals
{
	public record PriceDetails(Money preciePerPeriod,Money mantenance,Money accesory,Money totalPrice);
	
}
