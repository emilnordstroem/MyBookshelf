using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookshelf.DAL;
using MyBookshelf.Models;

namespace MyBookshelf.Controllers
{
    public class BookshelfController : Controller
    {
        private readonly BookContext _context;

        public BookshelfController(BookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.Include(book => book.Authors).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(book => book.Authors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult CreateBookRecommendation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookRecommendation(Book book)
        {
			if (book == null)
			{
				return View("Index");
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
			
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}


		public async Task<IActionResult> Edit(int? id)
        {
			throw new NotImplementedException();
		}

		[HttpPost]
        public async Task<IActionResult> Edit(int id, Book book)
        {
			throw new NotImplementedException();
		}

		public async Task<IActionResult> Delete(int? id)
        {
			throw new NotImplementedException();
		}

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
