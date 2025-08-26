using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Common.Entities
{
	public class Size
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public string Name { get; set; } // 150ml, 350ml, XL, M

		[MaxLength(20)]
		public string Unit { get; set; } // ml, g, size

		public bool IsActive { get; set; } = true;

		// Navigation Properties
		public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
	}
}
