using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		public int CustomerId { get; set; } // Foreign key for Customer

		public DateTime OrderDate { get; set; }

		public decimal TotalPrice { get; set; }

		// Navigation property for related OrderDetails
		public virtual List<OrderDetail> OrderDetails { get; set; }
	}
}
