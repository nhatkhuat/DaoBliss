using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class ProductCategory
	{
		[Key]
		public int ProductCategoryId { get; set; }

		[Required, StringLength(255)]
		public string ProductCategoryName { get; set; } = null!;

		public bool IsActive { get; set; }

		public virtual ICollection<Product>? Products { get; set; }
	}
}
