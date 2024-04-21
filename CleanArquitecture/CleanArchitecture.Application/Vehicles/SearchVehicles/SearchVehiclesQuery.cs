using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
	public sealed record SearchVehiclesQuery(DateOnly initDate,DateOnly endDate):IQuery<IReadOnlyList<VehicleResponse>>;
	
}
