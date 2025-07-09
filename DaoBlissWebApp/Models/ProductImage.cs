using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class ProductImage
	{
		[Key]
		public int ProductImageId { get; set; }

		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		[Required, StringLength(255)]
		public string ImageUrl { get; set; }

		[Required]
		public bool IsActive { get; set; }
	}
}
