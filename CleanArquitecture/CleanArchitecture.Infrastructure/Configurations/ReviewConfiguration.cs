using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Rentals;
using CleanArchitecture.Domain.Reviews;
using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
	internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.ToTable("review");
			builder.HasKey(review => review.Id);

			builder.Property(review => review.Rating)
				.HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

			builder.Property(review => review.Comentary)
				.HasMaxLength(200)
				.HasConversion(comentary => comentary.Value, value => new Comentary(value));

			builder.HasOne<Vehicle>()
				.WithMany()
				.HasForeignKey(review => review.Id);

			builder.HasOne<Rent>()
				.WithMany()
				.HasForeignKey(review => review.RentId);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(user => user.Id);
		}
	}
}
