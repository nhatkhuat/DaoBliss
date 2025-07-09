using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Models
{
	public class Voucher
	{

		[Key]
		public int VoucherId { get; set; }

		[Required, StringLength(255)]
		public string VoucherName { get; set; }

		public string? Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int? Quantity { get; set; }

		public decimal? Percent { get; set; }

		[Required]
		public bool IsActive { get; set; }

		[StringLength(255)]
		public string? VoucherCode { get; set; }

		public virtual ICollection<Order>? Orders { get; set; }
	}
}
