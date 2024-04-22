using CleanArchitecture.Data.Vehicles;
using CleanArchitecture.Domain.Rentals;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
	internal sealed class RentConfiguration : IEntityTypeConfiguration<Rent>
	{
		public void Configure(EntityTypeBuilder<Rent> builder)
		{
			builder.ToTable("rents");
			builder.HasKey(rent => rent.Id);

			builder.OwnsOne(rent => rent.PricePerPeriod, priceBuilder =>
			{
				priceBuilder.Property(coin => coin.MoneyType)
				.HasConversion(coinType => coinType.Code, code => MoneyType.FromCode(code!));
			});

			builder.OwnsOne(rent => rent.Maintenance, priceBuilder =>
			{
				priceBuilder.Property(coin => coin.MoneyType)
				.HasConversion(coinType => coinType.Code, code => MoneyType.FromCode(code!));
			});

			builder.OwnsOne(rent => rent.Accesory, priceBuilder =>
			{
				priceBuilder.Property(coin => coin.MoneyType)
				.HasConversion(coinType => coinType.Code, code => MoneyType.FromCode(code!));
			});

			builder.OwnsOne(rent => rent.TotalPrice, priceBuilder =>
			{
				priceBuilder.Property(coin => coin.MoneyType)
				.HasConversion(coinType => coinType.Code, code => MoneyType.FromCode(code!));
			});

			builder.OwnsOne(rent => rent.Term);

			builder.HasOne<Vehicle>()
				.WithMany()
				.HasForeignKey(rent => rent.VehicleId);

			builder.HasOne<User>()
				.WithMany()
				.HasForeignKey(rent => rent.UserId);
		}
	}
}
