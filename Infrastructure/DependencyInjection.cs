using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Services.CartService;
using Application.Services.OrderServices;
using Application.Services.ProductService;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			// Cấu hình DbContext của EF Core
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("MyCnn")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			// Map interface IApplicationDbContext (Application) tới implementation ApplicationDbContext (Infrastructure)
			services.AddScoped<IApplicationDbContext>(provider =>
				provider.GetRequiredService<ApplicationDbContext>());

			// Đăng ký các repository hoặc service khác nếu cần
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICartRepository, CartRepository>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderService, OrderService>();

			var mailsettings = configuration.GetSection("MailSettings");
			services.Configure<MailSettings>(mailsettings);
			services.AddTransient<IEmailSender, SendMailService>();

			return services;
		}
	}
}
