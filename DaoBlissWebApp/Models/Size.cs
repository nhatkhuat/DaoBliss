using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class Size
	{
		[Key]
		public int SizeId { get; set; }

		[Required, StringLength(20)]
		public string SizeName { get; set; } = null!;

		public string? Description { get; set; }

		public virtual ICollection<ProductSize>? ProductSizes { get; set; }
		public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
	}
}
