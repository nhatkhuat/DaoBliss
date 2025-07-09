using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class OrderDetail
	{
		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public string? ProductName { get; set; }

		public string? Thumbnail { get; set; }

		public int? SizeId { get; set; }

		public int Quantity { get; set; }

		public int UnitPrice { get; set; }

		public int TotalPrice { get; set; }

		[ForeignKey(nameof(OrderId))]
		public virtual Order Order { get; set; } = null!;
		[ForeignKey(nameof(ProductId))]
		public virtual Product Product { get; set; } = null!;
		[ForeignKey(nameof(SizeId))]
		public virtual  Size? Size { get; set; }
	}
}
