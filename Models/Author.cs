using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MyBookshelf.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public List<Book> Books { get; set; } = new();

		public override string ToString()
		{
			return Name;
		}
	}
}
