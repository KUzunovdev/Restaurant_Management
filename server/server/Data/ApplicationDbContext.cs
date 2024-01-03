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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the one-to-many relationship
            modelBuilder.Entity<MenuItem>()
                .HasOne(mi => mi.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(mi => mi.CategoryId);

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }

        /*

		Configuring the database relationships here
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			
			
		}
		*/
    }
}
