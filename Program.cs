using MyBookshelf.DAL;

namespace MyBookshelf
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews()
				.AddJsonOptions(options =>
					{
						options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
					}
				);
			builder.Services.AddDbContext<BookContext>();

			var app = builder.Build();

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();

			app.MapStaticAssets();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Bookshelf}/{action=Bookshelf}")
				.WithStaticAssets();

			app.Run();
		}
	}
}
