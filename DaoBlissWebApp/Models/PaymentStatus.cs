using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class PaymentStatus
	{
		[Key]
		public int PaymentStatusId { get; set; }

		public string? PaymentStatusName { get; set; }

		public string? Description { get; set; }

		public virtual ICollection<Order>? Orders { get; set; }
	}
}
