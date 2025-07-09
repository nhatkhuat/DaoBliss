using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class Slider
	{
		[Key]
		public int SliderId { get; set; }

		[StringLength(255)]
		public string? Tittle { get; set; }

		public string? Description { get; set; }

		[StringLength(255)]
		public string? ImageUrl { get; set; }

		[Required]
		public bool IsActive { get; set; }
	}
}
