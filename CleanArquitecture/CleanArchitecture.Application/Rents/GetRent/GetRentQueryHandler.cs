using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Application.Rents.GetRent
{
	internal sealed class GetRentQueryHandler : IQueryHandler<GetRentQuery, RentResponse>
	{
		private readonly ISqlConnectionFactory _sqlConnectionFactory;

		public GetRentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
		{
			_sqlConnectionFactory = sqlConnectionFactory;
		}

		public async Task<Result<RentResponse>> Handle(GetRentQuery request, CancellationToken cancellationToken)
		{
			using var connection = _sqlConnectionFactory.CreateConnection();

			var sql = """
				SELECT
					id AS Id,
					vehicle_id AS VehicleId,
					user_id AS UserId,
					status AS Status,
					price_per_period AS RentalPrice,
					price_per_period_coin_type AS CoinTypeRent,
					price_maintenance AS MaintenancePrice,
					coin_type_maintenance AS CoinTypeMaintenance,
					accesory_price AS AccesoryPrice,
					coin_type_accesory AS CoinTypeAccesorry,
					total_price AS TotalPrice,
					total_price_coin_type AS TotalPriceCoinType,
					init_duration AS InitDuration,
					end_duration AS EndDuration,
					cration_date AS CreationDate
				FROM rents WHERE id =@RentId 
				""";
			var rent =await	connection.QueryFirstOrDefaultAsync<RentResponse>(sql,new {request.RentId});

			return rent!;
		}
	}
}
