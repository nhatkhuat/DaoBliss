using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class PostFeedback
	{
		[Key]
		public int PostFeedbackId { get; set; }

		public string CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		public virtual ApplicationUser Customer { get; set; }

		public int PostId { get; set; }

		[ForeignKey("PostId")]
		public virtual Post Post { get; set; }

		[Required]
		public string Review { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? CreateAt { get; set; } = DateTime.UtcNow;

		public DateTime? ModifiedAt { get; set; }
	}
}
