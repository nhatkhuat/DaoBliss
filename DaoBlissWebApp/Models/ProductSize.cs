using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class ProductSize
	{
		public int SizeId { get; set; }

		[ForeignKey("SizeId")]
		public virtual Size Size { get; set; }

		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		public int Quantity { get; set; }

		public int Weight { get; set; }
	}
}
