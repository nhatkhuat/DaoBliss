
using DaoBlissWebApp.Interfaces.Repositories;
using DaoBlissWebApp.Common.Entities;

using DaoBlissWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DaoBlissWebApp.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderRepository(ApplicationDbContext context)
		{
			_context = context ;
		}

		public Task<Order> CreateOrderAsync(Order order)
		{
			throw new NotImplementedException();
		}

		public Task<List<OrderItem>> CreateOrderDetailsAsync(List<OrderItem> orderDetails)
		{
			throw new NotImplementedException();
		}

		public Task<UserAddress> GetDefaultCustomerAddressAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
