using DaoBlissWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DaoBlissWebApp.Data
{

	public class ShopDbContext : IdentityDbContext<ApplicationUser>
	{
		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
		{
		}
		public DbSet<Brand> Brands { get; set; }
		public DbSet<CustomerAddress> CustomerAddresses { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<PaymentStatus> PaymentStatuses { get; set; }
		public DbSet<PostCategory> PostCategories { get; set; }
		public DbSet<PostFeedback> PostFeedbacks { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductSize> ProductSizes { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }
		public DbSet<Rank> Ranks { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			base.OnConfiguring(builder);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderDetail>()
				.HasKey(od => new { od.OrderId, od.ProductId });

			modelBuilder.Entity<ProductSize>()
				.HasKey(ps => new { ps.ProductId, ps.SizeId });

			modelBuilder.Entity<Order>()
				.HasOne(o => o.Customer)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.CustomerId)
				.OnDelete(DeleteBehavior.Restrict);

			// Quan hệ ApplicationUser - Order (Saler)
			modelBuilder.Entity<Order>()
				.HasOne(o => o.Saler)
				.WithMany(u => u.SalesOrders)
				.HasForeignKey(o => o.SalerId)
				.OnDelete(DeleteBehavior.Restrict);

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				var tableName = entityType.GetTableName();
				if (tableName.StartsWith("AspNet"))
				{
					entityType.SetTableName(tableName.Substring(6));
				}
			}
		}
	}
}
