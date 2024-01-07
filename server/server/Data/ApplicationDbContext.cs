using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<MenuItem> MenuItems { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Table> Tables { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<InventoryItem> InventoryItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//one-to-many relationship between Categories and MenuItems
			modelBuilder.Entity<Category>()
				.HasMany(c => c.MenuItems)
				.WithOne(mi => mi.Category)
				.HasForeignKey(mi => mi.CategoryID);

			// one-to-many relationship between Customers and Orders
			modelBuilder.Entity<Customer>()
				.HasMany(c => c.Orders)
				.WithOne(o => o.Customer)
				.HasForeignKey(o => o.CustomerID);

			//one-to-many relationship between Staff and Orders
			modelBuilder.Entity<Order>()
				.HasMany(o => o.StaffMembers)
				.WithMany(s => s.Orders)
				.UsingEntity<Dictionary<string, object>>(
					"StaffOrder", // Name of the join table
					j => j.HasOne<Staff>().WithMany().HasForeignKey("StaffID"),
					j => j.HasOne<Order>().WithMany().HasForeignKey("OrderID")
				);

			// one-to-many relationship between Suppliers and InventoryItems
			modelBuilder.Entity<Supplier>()
				.HasMany(s => s.InventoryItems)
				.WithOne(ii => ii.Supplier)
				.HasForeignKey(ii => ii.SupplierID);

			base.OnModelCreating(modelBuilder);
		}

		
	}
}