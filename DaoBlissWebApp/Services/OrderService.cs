

using DaoBlissWebApp.Interfaces.Services;
using DaoBlissWebApp.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text;
using DaoBlissWebApp.Common.Entities;

namespace DaoBlissWebApp.Services.OrderServices
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly ICartService _cartService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IEmailSender _emailSender;
		public OrderService(IOrderRepository orderRepository, ICartService cartService, UserManager<ApplicationUser> userManager, IProductRepository productRepository, IEmailSender emailSender)
		{
			_orderRepository = orderRepository;
			_cartService = cartService;
			_userManager = userManager;
			_productRepository = productRepository;
			_emailSender = emailSender;
		}

		public async Task CreateOrderAsync(Order order, List<OrderItem> orderDetails, ApplicationUser user)
		{
			//if (order == null) throw new ArgumentNullException(nameof(order));
			//if (orderDetails == null || !orderDetails.Any()) throw new ArgumentException("Order details cannot be empty.", nameof(orderDetails));
			//if (user == null) throw new ArgumentNullException(nameof(user));

			//foreach (var orderDetail in orderDetails)
			//{

			//	ProductVariant productVariant = await _productRepository.GetProductVariantAsync(orderDetail.ProductVariantId.Value);

			//	if (productVariant.Quantity < orderDetail.Quantity)
			//	{
			//		throw new InvalidOperationException($"Insufficient stock for ProductVariant ID {orderDetail.ProductVariantId.Value}. Available: {productVariant.Quantity}, Requested: {orderDetail.Quantity}");
			//	}

			//	productVariant.Quantity -= orderDetail.Quantity;
			//	await _productRepository.UpdateProductVariantAsync(productVariant);
			//}

			//// Đặt các giá trị mặc định
			//order.CustomerId = user.Id;
			//order.OrderedDate = DateTime.UtcNow;
			//order.PaymentStatusId = 1; // Pending
			//order.OrderStatusId = 1;   // Pending
			//order.OrderCode =  "ORD" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();

			//// Lưu Order
			//var createdOrder = await _orderRepository.CreateOrderAsync(order);

			//// Gán OrderId cho OrderDetails
			//foreach (var detail in orderDetails)
			//{
			//	detail.OrderId = createdOrder.OrderId;
			//}

			//// Lưu OrderDetails
			//await _orderRepository.CreateOrderDetailsAsync(orderDetails);

			//await _orderHubContext.Clients.All.SendAsync("ReceiveOrderNotification");
			//// Xóa giỏ hàng sau khi đặt hàng thành công
			////await _cartService.ClearCartAsync(user.Id);

			//await _orderRepository.SaveChangesAsync();

			//// Gửi email xác nhận đơn hàng
			////string emailContent = GenerateOrderEmailHtml(createdOrder, orderDetails);
			////await _emailSender.SendEmailAsync(order.User., $"Xác nhận đơn hàng #{createdOrder.OrderNumber}", emailContent);

		}

		public async Task<UserAddress> GetDefaultCustomerAddressAsync(string userId)
		{
			return await _orderRepository.GetDefaultCustomerAddressAsync(userId);
		}

		private string GenerateOrderEmailHtml(Order order, List<OrderItem> details)
		{
			//var culture = new System.Globalization.CultureInfo("vi-VN");
			//var sb = new StringBuilder();

			//sb.Append($@"
			//     <h2>Xin chào {order.ShippingFullName},</h2>
			//     <p>Cảm ơn bạn đã đặt hàng tại <strong>Clothes Shop</strong>!</p>
			//     <p><strong>Mã đơn hàng:</strong> {order.OrderNumber}</p>
			//     <p><strong>Ngày đặt:</strong> {order.CreatedAt.ToString("dd/MM/yyyy HH:mm")}</p>
			//     <hr />
			//     <h3>Chi tiết đơn hàng:</h3>
			//     <table style='width:100%; border-collapse:collapse;' border='1' cellpadding='5'>
			//         <thead>
			//             <tr style='background:#f2f2f2;'>
			//                 <th>Sản phẩm</th>
			//                 <th>Giá</th>
			//                 <th>Số lượng</th>
			//                 <th>Thành tiền</th>
			//             </tr>
			//         </thead>
			//         <tbody>");

			//foreach (var item in details)
			//{
			//	sb.Append($@"
			//             <tr>
			//                 <td>{item.Name}</td>
			//                 <td>{item.UnitPrice.ToString("C0", culture)}</td>
			//                 <td>{item.Quantity}</td>
			//                 <td>{item.TotalPrice.ToString("C0", culture)}</td>
			//             </tr>");
			//}

			//sb.Append($@"
			//         </tbody>
			//     </table>
			//     <p><strong>Tổng tiền:</strong> {order.TotalPrice.ToString("C0", culture)}</p>
			//     <p><strong>Thanh toán:</strong> {order.PaymentMethod?.PaymentMethodName ?? "COD"}</p>
			//     <hr />
			//     <h4>Thông tin nhận hàng:</h4>
			//     <p>Người nhận: {order.ReceiverName}</p>
			//     <p>SĐT: {order.Phone}</p>
			//     <p>Email: {order.Email}</p>
			//     <p>Địa chỉ: {order.Address}</p>

			//     <br />
			//     <p>Chúng tôi sẽ liên hệ với bạn khi đơn hàng được xử lý.</p>
			//     <p style='color:gray;'>Trạng thái hiện tại: <strong>{order.OrderStatus?.OrderStatusName ?? "Pending"}</strong></p>
			//     <br />
			//     <p>Trân trọng,</p>
			//     <p><strong>Clothes Shop Team</strong></p>
			// ");

			//return sb.ToString();
			return null;
		}

	}
}
