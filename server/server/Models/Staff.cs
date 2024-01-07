using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace server.Models
{
	public class Staff
	{
		[Key]
		public int StaffID { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		// Foreign key for Role
		public int RoleID { get; set; }

		// Navigation properties
		[ForeignKey("RoleID")]
		public virtual Role Role { get; set; }

		// Many-to-many relationship with Orders
		public virtual ICollection<Order> Orders { get; set; }
	}
}
