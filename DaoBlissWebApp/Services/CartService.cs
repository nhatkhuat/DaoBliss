
using DaoBlissWebApp.Interfaces.Services;
using DaoBlissWebApp.Interfaces.Repositories;
using DaoBlissWebApp.Common.Entities;

namespace DaoBlissWebApp.Services.CartService
{
	public class CartService : ICartService
	{
		private readonly ICartRepository _cartRepository;

		public CartService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public Task AddToCartAsync()
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
