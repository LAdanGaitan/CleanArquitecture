using CleanArchitecture.Data.Abstractions;

namespace CleanArchitecture.Data.Vehicles
{
	public sealed class Vehicle : Entity
	{
		public Vehicle
		(
			Guid id,
			Model model,
			Vin vin,
			Money price,
			Money mantenance,
			DateTime? lastRentalDate,
			List<Accesory> accesory,
			Address? address
		) : base(id)
		{
			Model = model;
			Vin = vin;
			Price = price;
			Mantenance = mantenance;
			LastRentalDate = lastRentalDate;
			Accesorys = accesory;
			Address = address;
		}
		public Model? Model { get; private set; }
		public Vin? Vin { get; private set; }
		public Address? Address { get; private set; }
		public Money? Price { get; private set; }
		public Money? Mantenance { get; private set; }
		public DateTime? LastRentalDate { get; private set; }
		public List<Accesory> Accesorys { get; private set; } = new();

	}
}
