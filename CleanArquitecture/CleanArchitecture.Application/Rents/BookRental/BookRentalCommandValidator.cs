﻿using FluentValidation;

namespace CleanArchitecture.Application.Rents.BookRental
{
	public class BookRentalCommandValidator : AbstractValidator<BookRentalCommand>
	{
        public BookRentalCommandValidator()
        {
            RuleFor( c=> c.UserId).NotEmpty();
            RuleFor(c => c.VehicleId).NotEmpty();
            RuleFor(c => c.InitDate).LessThan(c => c.EndDate);
        }
    }
}
