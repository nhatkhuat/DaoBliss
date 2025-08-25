using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class OrderStatus
	{
		[Key]
		public int OrderStatusId { get; set; }

		[Required, StringLength(255)]
		public string OrderStatusName { get; set; } = null!;

		public string? Description { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<Order>? Orders { get; set; }
	}
}
