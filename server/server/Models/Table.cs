using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Table
	{
		[Key]
		public int TableID { get; set; }

		[Required]
		public int Number { get; set; }

		public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
        // Navigation property for Reservations (one-to-many)
        public virtual ICollection<Reservation> Reservations { get; set; }
	}
}
