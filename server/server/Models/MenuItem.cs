using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class MenuItem
	{
		//to do - add properties for category and fix  

		[Key]
		public int MenuItemId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
