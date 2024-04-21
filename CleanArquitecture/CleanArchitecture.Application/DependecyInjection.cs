using CleanArchitecture.Application.Abstractions.Behaviors;
using CleanArchitecture.Domain.Rentals;
using FluentValidation;
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
				configuration.AddOpenBehavior(typeof(LoginBehavior<,>));
				configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
			});

			services.AddValidatorsFromAssembly(typeof(DependecyInjection).Assembly);

			services.AddTransient<ServicePrice>();
			return services;
		}
	}
}
