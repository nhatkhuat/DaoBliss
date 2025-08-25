using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Category
	{
		[Key]
		public int ProductCategoryId { get; set; }

		[Required, StringLength(255)]
		public string ProductCategoryName { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
		public bool IsActive { get; set; } = true;

		public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
	}
}
