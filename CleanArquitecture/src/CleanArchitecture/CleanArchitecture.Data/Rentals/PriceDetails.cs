using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Rentals
{
    public record PriceDetails(Money preciePerPeriod,Money mantenance,Money accesory,Money totalPrice);
	
}
