using Microsoft.EntityFrameworkCore;
using MyBookshelf.Models;

namespace MyBookshelf.DAL
{
	public class BookContext : DbContext
	{

		public BookContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = MyBookshelfDatabase; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

	}
}
