using System.Diagnostics.CodeAnalysis;

namespace MyBookshelf.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? BookId { get; set; }
		public Book? Book { get; set; }
	}
}
