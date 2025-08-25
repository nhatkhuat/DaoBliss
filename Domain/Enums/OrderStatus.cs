using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.DomainLayer.Enums
{
	public enum OrderStatus
	{
		[Display(Name = "Chờ xử lý")]
		Pending,
		[Display(Name = "Đang đóng hàng")]
		Processing,
		[Display(Name = "Đã giao hàng")]
		Shipped,
		[Display(Name = "Hoàn tất")]
		Completed,
		[Display(Name = "Hủy đơn")]
		Cancelled
	}
}
