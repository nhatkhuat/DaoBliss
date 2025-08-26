
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;
using DaoBlissWebApp.Common.Entities;

namespace Application.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task AddProductAsync(Product product)
		{
			await _productRepository.AddProductAsync(product);
		}

		public async Task DeleteProductAsync(int id)
		{
			await _productRepository.DeleteProductAsync(id);
		}

		public async Task<List<Product>> GetAllProductsAsync()
		{
			return await _productRepository.GetAllProductsAsync();
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await _productRepository.GetProductByIdAsync(id);
		}

		public async Task<List<Product>> GetProductsByCategoriesAsync(List<int> categoryIds)
		{
			return await _productRepository.GetProductsByCategoriesAsync(categoryIds);
		}

		public async Task<List<Product>> SearchProductsAsync(string searchTerm)
		{
			return await _productRepository.SearchProductsAsync(searchTerm);
		}

		public async Task UpdateProductAsync(Product product)
		{
			await _productRepository.UpdateProductAsync(product);
		}

		public async Task<List<Category>> GetAllCategoriesAsync()
		{
			return await _productRepository.GetAllCategoriesAsync();
		}

		public async Task<List<Size>> GetAllSizesAsync()
		{
			return await _productRepository.GetAllSizesAsync();
		}


		public async Task<ProductVariant?> GetProductVariantAsync(int productVariantId)
		{
			return await _productRepository.GetProductVariantAsync(productVariantId);
		}

		public async Task UpdateProductVariantAsync(ProductVariant productVariant)
		{
			await _productRepository.UpdateProductVariantAsync(productVariant);
		}
	}
}
