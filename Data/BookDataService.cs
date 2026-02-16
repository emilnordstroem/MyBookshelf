using MyBookshelf.Models;

namespace MyBookshelf.Data
{
	public class BookDataService
	{
		private static List<Book> _books = new List<Book>();
		private static long _nextBookId = 1;

		public static List<Book> GetBooks()
		{
			return new List<Book>(_books);
		}

		public static Book? GetBookById (long id)
		{
			return _books.Where(book => book.Id == id).FirstOrDefault();
		}
		public static Book? PostBook(Book book)
		{
			if (_books.Where(book => book.Id == book.Id).FirstOrDefault() != null)
			{
				return null;
			}
			book.Id = _nextBookId++;
			_books.Add(book);
			return book;
		}
		public static Book? PutBook(long id, Book book)
		{
			if (book.Id != id)
			{
				return null;
			}
			Book? prevBook = _books.Where(currentBook => currentBook.Id == book.Id).FirstOrDefault();
			if (prevBook == null)
			{
				return null;
			}
			_books.Remove(prevBook);
			_books.Add(book);
			return book;
		}
		public static Book? DeleteBook(Book book)
		{
			if (_books.Remove(book))
			{
				return book;
			}
			return null;
		}
	}
}
