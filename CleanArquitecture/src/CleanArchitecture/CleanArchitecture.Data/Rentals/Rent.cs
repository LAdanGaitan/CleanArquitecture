using CleanArchitecture.Data.Abstractions;
using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Rentals.Events;

namespace CleanArchitecture.Domain.Rentals
{
	public sealed class Rent:Entity
	{
        private Rent(Guid id,Guid vehicleId,Guid userId,DateRange term,Money pricePerPeriod,Money maintenance,Money accesory,Money totalPrice,RentStatus status,DateTime creationDate):base(id)
        {
            VehicleId = vehicleId;
            UserId = userId;
            Term = term;
            PricePerPeriod = pricePerPeriod;
            Maintenance = maintenance;
            Accesory = accesory;
            TotalPrice = totalPrice;
            Status = status;
            CreationDate = creationDate;
        }
        public Guid VehicleId {  get; private set; }
        public Guid UserId { get;private set; }
        public Money? PricePerPeriod { get;private set; }
		public Money? Maintenance { get;private set; }
        public Money? Accesory { get; private set; }
        public Money? TotalPrice { get;private set; }
        public RentStatus Status { get; private set; }
        public DateRange? Term { get; private set; }
        public DateTime? CreationDate { get;private set; }
        public DateTime? ConfimatedDate { get;private set; }
        public DateTime? DenialDate { get;private set; }
        public DateTime? CompletedDate { get;private set; }
        public DateTime? CacellationDate { get;private set; }

        public static Rent Reserved(Guid vehicleId,Guid userId,DateRange term,DateTime creationDate,PriceDetails priceDatails)
        {
            var rent = new Rent(Guid.NewGuid(), vehicleId, userId, term, priceDatails.preciePerPeriod, priceDatails.mantenance, priceDatails.accesory, priceDatails.totalPrice, RentStatus.Reserved, creationDate);
            rent.RaiseDomainEvent(new RentReservedDomainEvent(rent.Id));
            return rent;
        }
    }
}
