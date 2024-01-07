using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Category
    {
		[Key]
		public int CategoryID { get; set; }

		[Required]
		[MaxLength(128)]
		public string Name { get; set; }

		// Navigation property for MenuItems (one-to-many)
		public virtual ICollection<MenuItem> MenuItems { get; set; }
	}
}
