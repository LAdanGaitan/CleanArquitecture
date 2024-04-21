namespace CleanArchitecture.Application.Rents.GetRent
{
	public sealed class RentResponse
	{
        public Guid Id { get; init; }
        public Guid  UserId { get; init; }
        public Guid VehicleId { get; init; }
        public int Status { get; init; }
        public decimal RentalPrice { get; init; }
        public string? CoinTypeRent { get; init; }
        public decimal MaintenancePrice { get; init; }
        public string? CoinTypeMaintenance { get; init; }
        public decimal AccesoryPrice {  get; init; }
        public string? CoinTypeAccesorry { get; init; } 
        public decimal TotalPrice {  get; init; }
        public string? TotalPriceCoinType { get; init; }
        public DateOnly InitDuration { get; init; }
        public DateOnly EndDuration { get; init; }
        public DateTime CreationDate { get; init; }
    }
}
