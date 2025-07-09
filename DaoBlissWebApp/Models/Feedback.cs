using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class Feedback
	{
		[Key]
		public int FeedbackId { get; set; }

		[Required]
		public string CustomerId { get; set; } = null!; 

		[ForeignKey("CustomerId")]
		public virtual ApplicationUser Customer { get; set; } = null!;

		[Required]
		public int OrderId { get; set; }

		[ForeignKey("OrderId")]
		public virtual Order Order { get; set; } = null!;

		[Required]
		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; } = null!;

		[Required]
		public string Review { get; set; } = null!;

		public string? Thumbnail { get; set; }

		public int Rating { get; set; }

		public bool IsActive { get; set; }

		public DateTime? CreateAt { get; set; }

		public DateTime? ModifiedAt { get; set; }
	}
}
