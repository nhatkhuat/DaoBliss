using Domain.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetAllProductsAsync()
		{
			return await _context.Products
				.Where(p => p.IsActive == true && p.Category.IsActive)
				.Include(p => p.Category)
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
					.ThenInclude(pv => pv.Size)
				.ToListAsync() ?? new List<Product>();
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await _context.Products
				.Where(p => p.Id == id &&
							p.IsActive == true &&
							p.Category.IsActive)
				.Include(p => p.Category)
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
					.ThenInclude(pv => pv.Size)
				.FirstOrDefaultAsync();
		}

		public async Task<List<Product>> GetProductsByCategoriesAsync(List<int> categoryIds)
		{
			return await _context.Products
				.ToListAsync() ?? new List<Product>();
		}

		public async Task<List<Product>> SearchProductsAsync(string searchTerm)
		{
			return await _context.Products
				.Where(p => p.IsActive == true &&
							p.Category.IsActive == true &&
							(p.Name.Contains(searchTerm) ||
							 p.Description.Contains(searchTerm)))
				.Include(p => p.Category)
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
				.Include(p => p.Variants
					.Where(v => v.IsActive &&
								v.Size.IsActive))
					.ThenInclude(pv => pv.Size)
				.ToListAsync() ?? new List<Product>();
		}

		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Category>> GetAllCategoriesAsync()
		{
			return await _context.Categories
				.Where(c => c.IsActive)
				.ToListAsync() ?? new List<Category>();
		}

		public async Task<List<Size>> GetAllSizesAsync()
		{
			return await _context.Sizes
				.Where(s => s.IsActive)
				.ToListAsync() ?? new List<Size>();
		}

		public async Task<ProductVariant?> GetProductVariantAsync(int productVariantId)
		{
			return await _context.Variants
				.Include(pv => pv.Product)
				.Include(pv => pv.Size)
				.FirstOrDefaultAsync(pv => pv.Id == productVariantId &&
										   pv.IsActive &&
										   pv.Size.IsActive);
		}

		public async Task UpdateProductVariantAsync(ProductVariant productVariant)
		{
			_context.Variants.Update(productVariant);
			await _context.SaveChangesAsync();
		}
	}


}
