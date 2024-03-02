using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.CW1._9135.DAL.Data;
using WAD.CW1._9135.DAL.Services.Interfaces;
using WAD.CW1._9135.DAL.Services.Repositories;

namespace WAD.CW1._9135.DAL
{
	public static class ConfigureServices
	{
		public static IServiceCollection DalServices(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<ICarRepository, CarRepository>();
			services.AddScoped<IRentalRepository, RentalRepository>();

			return services;
		}
	}
}
