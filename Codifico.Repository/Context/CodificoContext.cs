using Microsoft.EntityFrameworkCore;

namespace Codifico.Repository.Context
{
    public class CodificoContext : DbContext
	{
		public CodificoContext(DbContextOptions options) : base(options)
		{
		}

		public CodificoContext()
		{
		}
	}
}
