using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Supplier
	{
		[Key]
		public int SupplierID { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		public string ContactInfo { get; set; }

		// Navigation property for InventoryItems (one-to-many)
		public virtual ICollection<InventoryItem> InventoryItems { get; set; }
	}
}
