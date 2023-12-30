using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailId { get; set; }

		public int OrderId { get; set; } // Foreign key for Order

		public int MenuItemId { get; set; } // Foreign key for MenuItem

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		// Navigation properties
		public virtual Order Order { get; set; }
		public virtual MenuItem MenuItem { get; set; }
	}
}
