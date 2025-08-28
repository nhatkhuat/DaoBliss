using CloudinaryDotNet;
using DaoBlissWebApp.Common.Entities;
using DaoBlissWebApp.Data;
using DaoBlissWebApp.Interfaces;
using DaoBlissWebApp.Interfaces.Repositories;
using DaoBlissWebApp.Interfaces.Services;
using DaoBlissWebApp.Repositories;
using DaoBlissWebApp.Services;
using DaoBlissWebApp.Services.CartService;
using DaoBlissWebApp.Services.OrderServices;
using DaoBlissWebApp.Services.ProductService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Net.Http.Headers;

namespace DaoBlissWebApp
{
	public class Program
	{
		public static async Task Main(string[] args)
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
				options.Lockout.MaxFailedAccessAttempts = 5; // That bai n lan thi khóa
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

			builder.Services.AddHttpClient("Gemini", client =>
			{
				client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/");
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				client.Timeout = TimeSpan.FromSeconds(60); // Add timeout
			});
			builder.Services.AddLogging();
			var app = builder.Build();

			await CreateRolesAndAdminAsync(app);

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

			await app.RunAsync();
		}
		static async Task CreateRolesAndAdminAsync(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

				// Các role mặc định
				string[] roles = { "Admin", "Manager" };

				foreach (var role in roles)
				{
					if (!await roleManager.RoleExistsAsync(role))
					{
						await roleManager.CreateAsync(new IdentityRole(role));
					}
				}

				// Tạo tài khoản Admin mặc định
				string adminEmail = "admin@yourapp.com";
				string adminPassword = "Admin@123"; // đổi sau khi deploy

				var adminUser = await userManager.FindByEmailAsync(adminEmail);
				if (adminUser == null)
				{
					var newAdmin = new ApplicationUser
					{
						UserName = "admin",
						Email = adminEmail,
						EmailConfirmed = true
					};

					var result = await userManager.CreateAsync(newAdmin, adminPassword);
					if (result.Succeeded)
					{
						await userManager.AddToRoleAsync(newAdmin, "Admin");
					}
				}
			}
		}
	}
}
