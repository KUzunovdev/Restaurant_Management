using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Customer
	{
		[Key]
		public int CustomerID { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		public string ContactInfo { get; set; }

		// Navigation property for Orders (one-to-many)
		public virtual ICollection<Order> Orders { get; set; }

		// Navigation property for Reservations (one-to-many)
		public virtual ICollection<Reservation> Reservations { get; set; }
	}
}
