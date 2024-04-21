using CleanArchitecture.Data.Abstractions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rentals;
using CleanArchitecture.Domain.Reviews.Events;

namespace CleanArchitecture.Domain.Reviews
{
	public sealed class Review :Entity
	{
        private Review(Guid id,Guid vehicleId,Guid rentId,Guid userId,Rating rating,Comentary comentary, DateTime? cratedDate):base(id)
        {
            VehicleId = vehicleId;
            RentId = rentId;
            UserId = userId;
            Rating = rating;
            Comentary = comentary;
            CreatedDate = cratedDate;
        }
        public Guid VehicleId { get; private set; }
        public Guid RentId { get;private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get;private set; }
        public Comentary Comentary { get; private set; }
        public DateTime? CreatedDate { get;private set; }

        public static Result<Review?> Create(Rent rent, Rating rating, Comentary comentary,DateTime cratedDate)
        {
            if(rent.Status != RentStatus.Complete)
            {
                return Result.Failure<Review>(ReviewErrors.NotElegible);
            }
            var review = new Review(Guid.NewGuid(),rent.VehicleId,rent.Id,rent.UserId,rating,comentary, cratedDate);
            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

            return review;
        }
    }
}
