using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class PostCategory
	{
		[Key]
		public int PostCategoryId { get; set; }

		[Required]
		[StringLength(50)]
		public string PostCategoryName { get; set; }

		[Required]
		public bool IsActive { get; set; }

		// Navigation property
		public virtual ICollection<Post> Posts { get; set; }
	}
}
