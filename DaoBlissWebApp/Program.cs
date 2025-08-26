using Application;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Services.CartService;
using Application.Services.OrderServices;
using Application.Services.ProductService;
using DaoBlissWebApp.Common.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DaoBlissWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
			// Cấu hình DbContext của EF Core
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			// Đăng ký các repository hoặc service khác nếu cần
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
			builder.Services.AddScoped<ICartService, CartService>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();
			builder.Services.AddScoped<IOrderService, OrderService>();

			var mailsettings = builder.Configuration.GetSection("MailSettings");
			builder.Services.Configure<MailSettings>(mailsettings);
			builder.Services.AddTransient<IEmailSender, SendMailService>();
			var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //hi
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
