using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class ProductImage
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required, MaxLength(500)]
		public string ImageUrl { get; set; }

		[MaxLength(200)]
		public string AltText { get; set; }
		public int SortOrder { get; set; } = 0;
		public bool IsMain { get; set; } = false;

		[ForeignKey("ProductId")]
		public Product Product { get; set; }
	}
}
