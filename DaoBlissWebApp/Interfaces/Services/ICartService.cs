using DaoBlissWebApp.Common.Entities;


namespace DaoBlissWebApp.Interfaces.Services
{
	public interface ICartService
	{
		Task AddToCartAsync();
		Task<ProductVariant> GetProductVariantAsync(int? productVariantId);
		Task<ProductVariant> GetProductVariantBySizeAsync(int productId, int sizeId);
	}
}
