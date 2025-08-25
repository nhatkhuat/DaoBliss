using Domain.Entities;

namespace Application.Interfaces.Services
{
	public interface IProductService
	{
		Task<Product?> GetProductByIdAsync(int id);
		Task<List<Product>> GetAllProductsAsync();
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
		Task<List<Product>> GetProductsByCategoriesAsync(List<int> categoryIds);
		Task<List<Product>> SearchProductsAsync(string searchTerm);
		Task<List<Category>> GetAllCategoriesAsync();
		Task<List<Size>> GetAllSizesAsync();

		Task<ProductVariant?> GetProductVariantAsync(int productVariantId);
		Task UpdateProductVariantAsync(ProductVariant productVariant);
	}
}
