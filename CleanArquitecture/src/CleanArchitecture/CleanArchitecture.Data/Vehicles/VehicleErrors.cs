using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehicles
{
	public static class VehicleErrors
	{
		public static Error NotFound = new("Vehiculo.NotFound","There is no vehicle with this id");
	}
}
