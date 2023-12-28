using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class UserEntity
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Username { get; set; }

		[Required]
		[MaxLength(50)]
		public string Password { get; set; }



	}
}
