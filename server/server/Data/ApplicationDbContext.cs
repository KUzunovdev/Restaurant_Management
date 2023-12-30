using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
	public class ApplicationDbContext: DbContext
	{

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Models.UserEntity> Users { get; set; }
		
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<MenuItem> MenuItems { get; set; }

		/*

		Configuring the database relationships here
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			
			
		}
		*/
	}
}
