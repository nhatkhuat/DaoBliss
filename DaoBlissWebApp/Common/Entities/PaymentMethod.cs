using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Common.Entities
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
