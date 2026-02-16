using Microsoft.AspNetCore.Mvc;
using MyBookshelf.Data;
using MyBookshelf.Models;

namespace MyBookshelf.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
		{
			return BookDataService.GetBooks();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Book?>> GetBookById(long id)
		{
			return BookDataService.GetBookById(id);
		}

		[HttpPost]
		public async Task<ActionResult<Book?>> PostBook(Book book)
		{
			return BookDataService.PostBook(book);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Book?>> PutBook(long id, Book book)
		{
			return BookDataService.PutBook(id, book);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Book?>> DeleteBook(long id)
		{
			return BookDataService.DeleteBook(id);
		}

	}
}
