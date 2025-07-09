using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class Brand
	{
		[Key]
		public int BrandId { get; set; }

		[Required, StringLength(255)]
		public string BrandName { get; set; } = null!;

		public string? Description { get; set; }

		[Required, StringLength(255)]
		public string Logo { get; set; } = null!;

		public bool IsActive { get; set; }

		public virtual ICollection<Product>? Products { get; set; }
	}
}
