using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class CustomerAddress
	{
		[Key]
		public int CustomerAddressesId { get; set; }

		public string? Address { get; set; }

		public int ProvinceId { get; set; }

		public string? ProvinceName { get; set; }

		public int DistrictId { get; set; }

		public string? DistrictName { get; set; }

		[Required]
		public string WardCode { get; set; } = null!;

		public string? WardName { get; set; }

		public string? Phone { get; set; }

		public string? ReceiverName { get; set; }

		public bool IsDefault { get; set; }

		[Required]
		public string CustomerId { get; set; } = null!;

		[ForeignKey("CustomerId")]
		public virtual ApplicationUser Customer { get; set; } = null!;
	}
}
