using Microsoft.EntityFrameworkCore;
using server.Data;
//using server.Services;

namespace server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			
			//connect to the database
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
								options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			/* Add your custom services 
			builder.Services.AddScoped<OrderService>();
			builder.Services.AddScoped<OrderDetailService>();
			*/

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}