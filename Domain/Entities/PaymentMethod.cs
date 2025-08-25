using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class PaymentMethod
	{
		[Key]
		public int PaymentMethodId { get; set; }

		public string? PaymentMethodName { get; set; }

		public string? Description { get; set; }

		public virtual ICollection<Order>? Orders { get; set; }
	}
}
