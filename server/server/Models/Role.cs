using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Role
	{
		[Key]
		public int RoleID { get; set; }

		[Required]
		[MaxLength(128)]
		public string RoleName { get; set; }

		// Navigation property for Staff (one-to-many)
		public virtual ICollection<Staff> StaffMembers { get; set; }
	}
}
