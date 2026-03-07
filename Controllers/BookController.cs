using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookshelf.DAL;
using MyBookshelf.Models;

namespace MyBookshelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Books.Include(book => book.Authors).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

			var existingBook = await _context.Books
		        .Include(b => b.Authors)
		        .FirstOrDefaultAsync(b => b.Id == id);

			if (existingBook == null)
			{
				return NotFound();
			}

			existingBook.Title = book.Title;
			existingBook.Publisher = book.Publisher;
			existingBook.Published = book.Published;
			existingBook.Rating = book.Rating;
			existingBook.Comment = book.Comment;
			existingBook.Date = book.Date;

			existingBook.Authors.RemoveAll(a => !book.Authors.Any(incoming => incoming.Id == a.Id));

			var authorsToAdd = book.Authors
				.Where(incoming => !existingBook.Authors.Any(a => a.Id == incoming.Id))
				.ToList();
			existingBook.Authors.AddRange(authorsToAdd);

			foreach (var incoming in book.Authors)
			{
				var existing = existingBook.Authors.FirstOrDefault(a => a.Id == incoming.Id);
				if (existing != null)
				{
					existing.Name = incoming.Name;
				}
			}

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            if (book == null)
            {
				return BadRequest();
			}

			book.Id = 0; // Force EF Core to treat this as a new entity - otherwise conflict with identify property

			var resolvedAuthors = new List<Author>();
			foreach (var author in book.Authors)
			{
				var existingAuthor = await _context.Authors
					.FirstOrDefaultAsync(a => a.Id == author.Id);

				if (existingAuthor != null)
				{
					resolvedAuthors.Add(existingAuthor);
				}
				else
				{
					author.Id = 0;
					resolvedAuthors.Add(author); // new author
				}
			}

			book.Authors = resolvedAuthors;

			try
			{
				_context.Books.Add(book);
				await _context.SaveChangesAsync();
				return CreatedAtAction("GetBook", new { id = book.Id }, book);
			}
			catch (Exception exception)
			{
				return StatusCode(500, exception.Message);
			}
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books
                .Include(book => book.Authors)
                .FirstOrDefaultAsync(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
			_context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
