using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class Reservation
	{
		[Key]
		public int ReservationID { get; set; }

		public int CustomerID { get; set; }

		public int TableID { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime ReservationDate { get; set; }

		// Navigation properties
		[ForeignKey("CustomerID")]
		public virtual Customer Customer { get; set; }

		[ForeignKey("TableID")]
		public virtual Table Table { get; set; }
	}
}
