using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Common.Entities
{
	public class Article
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(300)]
		public string Title { get; set; }

		[Required, MaxLength(300)]
		public string Slug { get; set; }

		[MaxLength(500)]
		public string Summary { get; set; }

		[Required]
		[Column(TypeName = "ntext")]
		public string Content { get; set; }

		[MaxLength(500)]
		public string FeaturedImageUrl { get; set; }

		public string? AuthorId { get; set; }

		[MaxLength(50)]
		public string Status { get; set; } = "Draft";

		public int ViewCount { get; set; } = 0;
		public bool IsHot { get; set; } = false;

		public DateTime? PublishedAt { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		// Navigation Properties
		[ForeignKey("AuthorId")]
		public ApplicationUser Author { get; set; }

	}
}
