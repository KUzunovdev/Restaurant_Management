using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }

		public int CustomerID { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime OrderDate { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal TotalPrice { get; set; }

		// Navigation properties
		public virtual Customer Customer { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
		public virtual ICollection<Staff> StaffMembers { get; set; }
	}
}
