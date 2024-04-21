using CleanArchitecture.Data.Vehicles;

namespace CleanArchitecture.Domain.Rentals
{
	public class ServicePrice
	{
        public PriceDetails  CalculatePrice(Vehicle vehicle,DateRange term)
		{
			var moneyType = vehicle.Price!.MoneyType;

			var pricePerPeriod = new Money(term.NumberOfDays * vehicle.Price.Amouth,moneyType);

            decimal porcetangeCharge = 0;
            foreach (var accesory in vehicle.Accesorys)
            {
                porcetangeCharge += accesory switch 
                { 
                    Accesory.AppleCar or Accesory.AndroidCar => 0.05m,
                    Accesory.AirConditioning => 0.01m,
                    Accesory.Maps => 0.01m,
                    _ => 0
                };
            }

            var accesoryCharges = Money.Zero(moneyType);

            if(porcetangeCharge > 0)
            {
                accesoryCharges = new Money(pricePerPeriod.Amouth * porcetangeCharge, moneyType);
            }

            var totalPrice = Money.Zero();
            totalPrice += pricePerPeriod;

            if (!vehicle.Mantenance!.IsZero())
            {
                totalPrice += vehicle.Mantenance;
            }
            totalPrice += accesoryCharges;

            return new PriceDetails(pricePerPeriod,vehicle.Mantenance,accesoryCharges, totalPrice);
        }
    }
}
