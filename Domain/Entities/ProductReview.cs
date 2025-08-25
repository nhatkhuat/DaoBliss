using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class ProductReview
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public string UserId { get; set; }

		public int? OrderId { get; set; }

		[Required]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
		public int Rating { get; set; }

		[MaxLength(200)]
		public string Title { get; set; }

		[Column(TypeName = "ntext")]
		public string Comment { get; set; }
		public bool IsVerified { get; set; } = false;
		public bool IsApproved { get; set; } = false;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		// Navigation Properties
		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		[ForeignKey("UserId")]
		public ApplicationUser User { get; set; }

		[ForeignKey("OrderId")]
		public Order Order { get; set; }
	}
}
