namespace MyBookshelf.Models
{
	public class Book : Media
	{
		public Book(long id, string title, string[] authors, double rating, string comment, short ratedInYear) : base(id, title, authors, rating, comment, ratedInYear)
		{
		}

		public Book(long id, string title, string[] authors, string image, double rating, string comment, short ratedInYear) : base(id, title, authors, image, rating, comment, ratedInYear)
		{
		}
	}
}
