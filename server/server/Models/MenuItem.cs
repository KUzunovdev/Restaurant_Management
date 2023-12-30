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
	}
}
