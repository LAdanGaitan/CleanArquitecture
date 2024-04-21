using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rentals;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Application.Rents.BookRental
{
	internal sealed class BookRentalCommandHandler : ICommandHandler<BookRentalCommand, Guid>
	{
		private readonly IUserRepository _userRepository;
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IRentRepository _rentRepository;
		private readonly ServicePrice _servicePrice;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IDateTimeProvider _dateTimeProvider;
		public BookRentalCommandHandler(IUserRepository userRepository, IVehicleRepository vehicleRepository, IRentRepository rentRepository, ServicePrice servicePrice, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
		{
			_userRepository = userRepository;
			_vehicleRepository = vehicleRepository;
			_rentRepository = rentRepository;
			_servicePrice = servicePrice;
			_unitOfWork = unitOfWork;
			_dateTimeProvider = dateTimeProvider;
		}

		public async Task<Result<Guid>> Handle(BookRentalCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
			if (user is null)
			{
				return Result.Failure<Guid>(UserErrors.NotFound);
			}

			var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId, cancellationToken);
			if (vehicle is null)
			{
				return Result.Failure<Guid>(VehicleErrors.NotFound);
			}
			var term = DateRange.Create(request.InitDate, request.EndDate);
			if (await _rentRepository.IsOverlappingAsync(vehicle, term, cancellationToken))
			{
				return Result.Failure<Guid>(RentError.Overlap);
			}

			var rent = Rent.Reserved(vehicle, user.Id, term,_dateTimeProvider.CurrentTime, _servicePrice);
			_rentRepository.Add(rent);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
			return rent.Id;
		}
	}
}
