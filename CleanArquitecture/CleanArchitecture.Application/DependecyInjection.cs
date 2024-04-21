using CleanArchitecture.Domain.Rentals;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
	public static  class DependecyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssemblies(typeof(DependecyInjection).Assembly);
			});

			services.AddTransient<ServicePrice>();
			return services;
		}
	}
}
