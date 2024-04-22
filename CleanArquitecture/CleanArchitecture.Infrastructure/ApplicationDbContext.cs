using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure
{
	public sealed class ApplicationDbContext:DbContext,IUnitOfWork
	{
		public ApplicationDbContext(DbContextOptions options):base(options) 
		{ 
		}
	}
}
