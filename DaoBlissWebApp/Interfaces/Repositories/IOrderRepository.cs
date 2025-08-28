using DaoBlissWebApp.Common.Entities;


namespace DaoBlissWebApp.Interfaces.Repositories
{
	public interface IOrderRepository
	{
		Task<Order> CreateOrderAsync(Order order);
		Task<List<OrderItem>> CreateOrderDetailsAsync(List<OrderItem> orderDetails);
		Task<UserAddress> GetDefaultCustomerAddressAsync(string userId);
		Task SaveChangesAsync();
	}
}
