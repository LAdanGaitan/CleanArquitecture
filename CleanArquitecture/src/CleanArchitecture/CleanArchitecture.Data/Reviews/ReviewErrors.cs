using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews
{
	public static class ReviewErrors
	{
		public static readonly Error NotElegible = new Error("Review.NotEligible","This review and rating for the car is not eligible becasuse it has not yet been completed");
	}
}
