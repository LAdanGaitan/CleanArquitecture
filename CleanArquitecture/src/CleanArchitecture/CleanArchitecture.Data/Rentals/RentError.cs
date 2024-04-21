using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rentals
{
	public static class RentError
	{
		public static Error NotFound = new Error("Rent.Found","The rental with the specified id was not found");
		public static Error Overlap = new Error("Rent.Overlap", "The rental is being take by two or more clients at the same time on the same date");
		public static Error NotReserved = new Error("Rent.NotReserved","The rental is not reserved");
		public static Error NotConfimed = new Error("Rent.NotConfirmed", "The rental is not Confirmed");
		public static Error AlReadyStarted = new Error("Rent.AlReadyStarted", "The rental has already started");
	}
}
