using DaoBlissWebApp.Interfaces;
using DaoBlissWebApp.Interfaces.Repositories;
using DaoBlissWebApp.Interfaces.Services;
using DaoBlissWebApp.Services;
using DaoBlissWebApp.Services.CartService;
using DaoBlissWebApp.Services.OrderServices;
using DaoBlissWebApp.Services.ProductService;
using DaoBlissWebApp.Common.Entities;
using DaoBlissWebApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DaoBlissWebApp.Data;

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
			builder.Services.Configure<IdentityOptions>(options =>
			{
				// Thiet lap Password
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false; // Không bat co tu đac biet
				options.Password.RequireUppercase = false; // Không bat buoc chu in
				options.Password.RequiredLength = 3;
				options.Password.RequiredUniqueChars = 1; // So ky tu rieng biet

				// Cau hinh Lockout - khóa user
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
				options.Lockout.MaxFailedAccessAttempts = 3; // That bai n lan thi khóa
				options.Lockout.AllowedForNewUsers = true;

				// Cau hinh User.
				options.User.AllowedUserNameCharacters = // các ky tu đat tên user
					"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;  // Email là duy nhat

				// Cau hinh đăng nhap.
				options.SignIn.RequireConfirmedEmail = true;            // Cau hinh xác thuc đia chi email
				options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thuc so đien thoai
				options.SignIn.RequireConfirmedAccount = true;         // Yêu cau xác thuc tài khoan khi đăng nhap

			});
			var mailsettings = builder.Configuration.GetSection("MailSettings");
			builder.Services.Configure<MailSettings>(mailsettings);
			builder.Services.AddTransient<IEmailSender, SendMailService>();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/login"; // Trang chuyển đến khi chưa đăng nhập
				options.LogoutPath = "/logout"; // Đường dẫn đăng xuất
				options.AccessDeniedPath = "/accessDenied.html"; // Đường dẫn khi truy cập bị từ chối
			});
			builder.Services.AddAuthentication().AddGoogle(options =>
			{
				var gconfig = builder.Configuration.GetSection("Authentication:Google");
				options.ClientId = gconfig["ClientId"];
				options.ClientSecret = gconfig["ClientSecret"];
				options.CallbackPath = "/login-with-google";// Đường dẫn callback sau khi đăng nhập thành công mặc định
				options.Events.OnRemoteFailure = context =>
				{
					context.Response.Redirect($"/login");
					context.HandleResponse();
					return Task.CompletedTask;
				};
			})//.AddFacebook()
			;

			var app = builder.Build();
			app.MapGet("/", context =>
			{
				context.Response.Redirect("/HomePage");
				return Task.CompletedTask;
			});
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

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
