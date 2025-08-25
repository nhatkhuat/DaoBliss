using Domain.Entities;

namespace Application.Interfaces.Services
{
	public interface ICartService
	{
		Task AddToCartAsync();
		Task<ProductVariant> GetProductVariantAsync(int? productVariantId);
		Task<ProductVariant> GetProductVariantBySizeAsync(int productId, int sizeId);
	}
}
