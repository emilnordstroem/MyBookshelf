using Microsoft.AspNetCore.Mvc;
using MyBookshelf.Data;
using MyBookshelf.Models;

namespace MyBookshelf.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		[HttpGet("books")]
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
		{
			return BookDataService.GetBooks();
		}

		[HttpGet("books/{id}")]
		public async Task<ActionResult<Book?>> GetBookById(long id)
		{
			return BookDataService.GetBookById(id);
		}

		[HttpPost("books")]
		public async Task<ActionResult<Book?>> PostBook(Book book)
		{
			return BookDataService.PostBook(book);
		}

		[HttpPut("books/{id}")]
		public async Task<ActionResult<Book?>> PutBook(long id, Book book)
		{
			return BookDataService.PutBook(id, book);
		}

		[HttpDelete("books/{id}")]
		public async Task<ActionResult<Book?>> DeleteBook(long id)
		{
			return BookDataService.DeleteBook(id);
		}

	}
}
