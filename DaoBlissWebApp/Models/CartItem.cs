using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class CartItem
	{
		[Key]
		public int CartItemId { get; set; }

		[Required]
		public string UserId { get; set; } = null!;

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;

		[Required]
		public int ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public virtual Product Product { get; set; } = null!;

		public int? SizeId { get; set; }

		[ForeignKey(nameof(SizeId))]
		public virtual Size? Size { get; set; }

		[Required]
		public int Quantity { get; set; }

		public int UnitPrice { get; set; }

		public int TotalPrice => Quantity * UnitPrice;

		public DateTime AddedAt { get; set; } = DateTime.UtcNow;
	}

}
