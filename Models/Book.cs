namespace MyBookshelf.Models
{
	public class Book : Media
	{
		public Book(long id, string title, List<string> authors, double rating, string comment, short ratedInYear) : base(id, title, authors, rating, comment, ratedInYear)
		{
		}

		public Book(long id, string title, List<string> authors, string imageUrl, double rating, string comment, short ratedInYear) : base(id, title, authors, imageUrl, rating, comment, ratedInYear)
		{
		}
	}
}
