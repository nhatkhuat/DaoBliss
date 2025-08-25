using Domain.Entities;

namespace Application.Interfaces.Repositories
{
	public interface ICartRepository
	{
		//Task<CartItem?> GetCartItemAsync(int cartItemId);
		//Task<List<CartItem>> GetCartItemsByUserAsync(string userId);
		//Task AddCartItemAsync(CartItem cartItem);
		//Task UpdateCartItemAsync(CartItem cartItem);
		Task DeleteCartItemAsync(int cartItemId);
		Task<ProductVariant> GetProductVariantAsync(int? productVariantId);
		Task<ProductVariant> GetProductVariantBySizeAsync(int productId, int sizeId);
		Task ClearCartAsync(string userId);
	}
}
