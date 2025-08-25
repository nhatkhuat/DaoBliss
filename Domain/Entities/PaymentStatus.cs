using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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
