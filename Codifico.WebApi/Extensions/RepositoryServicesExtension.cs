using Codifico.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Codifico.WebApi.Extensions
{
	public static class RepositoryServicesExtension
	{
		public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<CodificoContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
