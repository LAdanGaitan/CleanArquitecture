using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users
{
	public static class UserErrors
	{
		public static Error NotFound = new("User.Found", "The user searched for this id does not exist");
		public static Error InvalidCredentials = new("User.InvalidCredentials","The credentials are incorret");
	}
}
