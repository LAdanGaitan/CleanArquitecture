using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rentals;
using Dapper;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles
{
	internal sealed class SeachVehicleQueryHandler : IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
	{
		private static readonly int[] ActiveRentStatuses = 
		{
			(int)RentStatus.Reserved,
			(int)RentStatus.Confimed,
			(int)RentStatus.Complete
		};

		private readonly ISqlConnectionFactory _sqlConnectionFactory;
		
		public SeachVehicleQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
		{
			_sqlConnectionFactory = sqlConnectionFactory;
		}

		public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(SearchVehiclesQuery request, CancellationToken cancellationToken)
		{
			if(request.initDate > request.endDate)
			{
				return new List<VehicleResponse>();
			}
			
			using var connection = _sqlConnectionFactory.CreateConnection();
		

			const string sql = """
					SELECT
						a.id as Id,
						a.model as Model,
						a.vin as Vin,
						a.price as Price,
						a.coin_type as CoinType,
						a.direction_country as Country,
						a.direction_departament as Departament,
						a.direction_Province as Province,
						a.direction_street as Street
					FROM vehicles AS a
					WHERE NOT EXISTS
					(
						SELECT 1
						FROM rents AS b
						WHERE 
							b.vehicle_id = a.id
							b.duration_init <= @EndDate AND
							b.duration_end >= @StartDate AND
							b.status = ANY(@ActiveRentStatuses)
					)
				"""
			;

			var vehicles = await connection.QueryAsync<VehicleResponse, DirectionResponse, VehicleResponse>(sql, (vehicle, direction) => { vehicle.Direction = direction; return vehicle; }, new
			{
				StartDate = request.initDate,
				EndDate= request.endDate,
				ActiveRentStatuses
			},
			splitOn:"Country"
			
			);

			return vehicles.ToList();

		}
	}
}
