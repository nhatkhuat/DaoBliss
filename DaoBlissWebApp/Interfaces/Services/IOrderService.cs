using DaoBlissWebApp.Common.Entities;


namespace Application.Interfaces.Services
{
	public interface IOrderService
	{
		Task CreateOrderAsync(Order order, List<OrderItem> orderDetails, ApplicationUser user);
		Task<UserAddress> GetDefaultCustomerAddressAsync(string userId);
	}
}
