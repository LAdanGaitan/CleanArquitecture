﻿using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Rentals;
using CleanArchitecture.Domain.Rentals.Events;
using CleanArchitecture.Domain.Users;
using MediatR;

namespace CleanArchitecture.Application.Rents.BookRental
{
	internal sealed class BookRentalDomainHandler : INotificationHandler<RentReservedDomainEvent>
	{
		private readonly IRentRepository _rentRepository;
		private readonly IUserRepository _userRepository;
		private readonly IEmailService _emailService;

		public BookRentalDomainHandler(IRentRepository rentRepository, IUserRepository userRepository, IEmailService emailService)
		{
			_rentRepository = rentRepository;
			_userRepository = userRepository;
			_emailService = emailService;
		}

		public async Task Handle(RentReservedDomainEvent notification, CancellationToken cancellationToken)
		{
			var rent = await _rentRepository.GetByIdAsync(notification.RentId,cancellationToken);
			if(rent is null)
			{
				return;
			}
			var user = await _userRepository.GetByIdAsync(rent.UserId,cancellationToken);
			if(user is null)
			{
				return;
			}
			await _emailService.SendAsync(user.Email!,"Rent Reserved","You have to confim this reservation otherwise it will be lost");
		}
	}
}
