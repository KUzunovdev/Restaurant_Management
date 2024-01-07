using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
	public class MenuItem
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		public string Description { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		// Foreign key for Category
		public int CategoryID { get; set; }

		// Navigation property for Category
		[ForeignKey("CategoryID")]
		public virtual Category Category { get; set; }

		// Navigation property for OrderDetails (many-to-many)
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
