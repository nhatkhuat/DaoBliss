using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class Rank
	{
		[Key]
		public int RankId { get; set; }

		[Required, StringLength(100)]
		public string RankName { get; set; } = string.Empty;

		public string? Description { get; set; }

		public int MinTotalSpent { get; set; }

		public bool IsActive { get; set; }

		// Navigation property
		public virtual ICollection<ApplicationUser>? Users { get; set; }
	}
}
