using DaoBlissWebApp.Interfaces.Repositories;
using DaoBlissWebApp.Common.Entities;

using DaoBlissWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DaoBlissWebApp.Repositories
{
	public class CartRepository : ICartRepository
	{
		private readonly ApplicationDbContext _context;

		public CartRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task ClearCartAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCartItemAsync(int cartItemId)
		{
			throw new NotImplementedException();
		}

		public Task<ProductVariant> GetProductVariantAsync(int? productVariantId)
		{
			throw new NotImplementedException();
		}

		public Task<ProductVariant> GetProductVariantBySizeAsync(int productId, int sizeId)
		{
			throw new NotImplementedException();
		}
	}
}
