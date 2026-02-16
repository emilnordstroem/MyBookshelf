using MyBookshelf.Models;

namespace MyBookshelf.Data
{
	public class BookDataService
	{
		private static List<Book> _books = new List<Book>();
		private static long _nextBookId = 1;

		public static Book? GetBookById (long id)
		{
			return _books.Where(book => book.Id == id).FirstOrDefault();
		}
		public static Book? PostBook(Book book)
		{

			return book;
		}
	}
}
