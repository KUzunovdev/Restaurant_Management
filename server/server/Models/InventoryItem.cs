using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class InventoryItem
	{
		[Key]
		public int InventoryItemID { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		public int Quantity { get; set; }

		// Foreign key for Supplier
		public int SupplierID { get; set; }

		// Navigation property for Supplier
		[ForeignKey("SupplierID")]
		public virtual Supplier Supplier { get; set; }
	}
}
