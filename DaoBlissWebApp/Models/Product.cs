using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoBlissWebApp.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required, StringLength(255)]
		public string ProductName { get; set; }

		public int Price { get; set; }

		public int TotalQuantity { get; set; }

		public decimal? Discount { get; set; }

		public string? Description { get; set; }

		[StringLength(255)]
		public string? Thumbnail { get; set; }

		public bool? IsActive { get; set; }

		public double? RatedStar { get; set; }

		public int? BrandId { get; set; }

		[ForeignKey("BrandId")]
		public virtual Brand? Brand { get; set; }

		public int? ProductCategoryId { get; set; }

		[ForeignKey("ProductCategoryId")]
		public virtual ProductCategory? ProductCategory { get; set; }

		public virtual ICollection<ProductSize> ProductSizes { get; set; }
		public virtual ICollection<ProductImage> ProductImages { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
