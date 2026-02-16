using MyBookshelf.Data;
using Scalar.AspNetCore;

namespace MyBookshelf
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddOpenApi();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();

			app.MapScalarApiReference();

			app.MapStaticAssets();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Bookshelf}/{action=Bookshelf}/{id?}")
				.WithStaticAssets();

			app.Run();
		}
	}
}
