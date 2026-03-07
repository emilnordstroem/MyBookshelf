using System.Diagnostics.CodeAnalysis;

namespace MyBookshelf.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Book> Books { get; set; } = new();

		public override string ToString()
		{
			return Name;
		}
	}
}
