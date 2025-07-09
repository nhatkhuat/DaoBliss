using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		public string CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		public virtual ApplicationUser Customer { get; set; }

		public DateTime? OrderedDate { get; set; }

		public DateTime? ReceiveDate { get; set; }

		[Required, StringLength(255)]
		public string ReceiverName { get; set; }

		[Required, StringLength(20)]
		public string Phone { get; set; }

		[Required, StringLength(255)]
		public string Email { get; set; }

		[Required, StringLength(2000)]
		public string Address { get; set; }

		[Required, StringLength(255)]
		public string WardCode { get; set; }

		[StringLength(255)]
		public string? WardName { get; set; }

		public int DistrictId { get; set; }

		[StringLength(255)]
		public string? DistrictName { get; set; }

		public int ProvinceId { get; set; }

		[StringLength(255)]
		public string? ProvinceName { get; set; }

		public int TotalPrice { get; set; }

		public int ShippingFee { get; set; }

		public int? VoucherId { get; set; }

		[ForeignKey("VoucherId")]
		public virtual Voucher? Voucher { get; set; }

		public decimal? VoucherPercent { get; set; }

		public int TotalAmount { get; set; }

		public int TotalGram { get; set; }

		[Required]
		public int PaymentMethodId { get; set; }

		[ForeignKey("PaymentMethodId")]
		public virtual PaymentMethod PaymentMethod { get; set; }

		public int PaymentStatusId { get; set; }

		[ForeignKey("PaymentStatusId")]
		public virtual PaymentStatus PaymentStatus { get; set; }

		public int OrderStatusId { get; set; }

		[ForeignKey("OrderStatusId")]
		public virtual OrderStatus OrderStatus { get; set; }

		[StringLength(255)]
		public string? ShippingCode { get; set; }

		public string? SalerId { get; set; }

		[ForeignKey("SalerId")]
		public virtual ApplicationUser? Saler { get; set; }

		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }
	}
}
