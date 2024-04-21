using CleanArchitecture.Data.Abstractions;
using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Abstractions;
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

        public static Rent Reserved(Vehicle vehicle,Guid userId,DateRange term,DateTime creationDate,ServicePrice servicePrice)
        {
            var priceDetails = servicePrice.CalculatePrice(vehicle,term);
            var rent = new Rent(Guid.NewGuid(), vehicle.Id, userId, term, priceDetails.preciePerPeriod, priceDetails.mantenance, priceDetails.accesory, priceDetails.totalPrice, RentStatus.Reserved, creationDate);
            rent.RaiseDomainEvent(new RentReservedDomainEvent(rent.Id));
            vehicle.LastRentalDate = creationDate;
            return rent;
        }

        public Result Confirm(DateTime utcNow)
        {
            if(Status != RentStatus.Reserved)
            {
                return Result.Failure(RentError.NotReserved);
            }

            Status = RentStatus.Confimed;
            ConfimatedDate = utcNow;

            RaiseDomainEvent(new RentConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Decline(DateTime utcNow)
        {
            if(Status != RentStatus.Reserved)
            {
                return Result.Failure(RentError.NotReserved);
            }

            Status = RentStatus.Refused;
            DenialDate = utcNow;
            RaiseDomainEvent(new RefusedRentDomainEvent(Id));
            return Result.Success();
        }

		public Result Cancelled(DateTime utcNow)
		{
			if (Status != RentStatus.Confimed)
			{
				return Result.Failure(RentError.NotConfimed);
			}

			Status = RentStatus.Cancelled;
			CacellationDate = utcNow;
			RaiseDomainEvent(new RefusedRentDomainEvent(Id));
			return Result.Success();
		}
	}
}
