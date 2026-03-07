
namespace MyBookshelf.Models
{
	public class Book : IRecommendable
	{
		public int Id { get; set; }
		public  string Title { get; set; }
		public List<Author> Authors { get; set; } = new();
		public string Publisher { get; set; }
		public DateTime Published { get; set; }
		
		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime Date { get; set; }

		public Book()
		{
		}

	}

}
