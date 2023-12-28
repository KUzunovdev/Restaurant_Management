using Microsoft.EntityFrameworkCore;

namespace server.Data
{
	public class ApplicationDbContext: DbContext
	{

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Models.UserEntity> Users { get; set; }
	}
}
