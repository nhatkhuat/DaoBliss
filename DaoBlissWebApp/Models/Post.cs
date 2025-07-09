using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class Post
	{
		[Key]
		public int PostId { get; set; }

		public string? Title { get; set; }

		public string? Content { get; set; }

		[StringLength(255)]
		public string? Thumbnail { get; set; }

		public string? AuthorId { get; set; }

		[ForeignKey("AuthorId")]
		public virtual ApplicationUser? Author { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int? PostCategoryId { get; set; }

		[ForeignKey("PostCategoryId")]
		public virtual PostCategory? PostCategory { get; set; }

		public virtual ICollection<PostFeedback> PostFeedbacks { get; set; }
	}
}
