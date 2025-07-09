using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class ApplicationUser : IdentityUser
	{

		[StringLength(50)]
		public string? FirstName { get; set; }

		[StringLength(50)]
		public string? LastName { get; set; }

		public bool? Gender { get; set; }

		public DateTime? Dob { get; set; }


		[StringLength(255)]
		public string? ProfilePictureUrl { get; set; }

		[Required]
		public bool IsBanned { get; set; }

		public int? RankId { get; set; }

		[ForeignKey("RankId")]
		public virtual Rank? Rank { get; set; }

		public virtual ICollection<CustomerAddress>? CustomerAddresses { get; set; }
		public virtual ICollection<Order>? Orders { get; set; }
		public virtual ICollection<Order>? SalesOrders { get; set; }
		public virtual ICollection<Feedback>? Feedbacks { get; set; }
		public virtual ICollection<Post>? Posts { get; set; }
		public virtual ICollection<PostFeedback>? PostFeedbacks { get; set; }
	}
}
