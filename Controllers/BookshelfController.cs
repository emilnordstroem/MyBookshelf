using Microsoft.AspNetCore.Mvc;
using MyBookshelf.Data;
using MyBookshelf.Models;

namespace MyBookshelf.Controllers
{
	public class BookshelfController : Controller
	{
		public IActionResult Bookshelf()
		{
			IEnumerable<Book> books = BookDataService.GetBooks();
			ViewBag.books = books;
			return View();
		}

	}
}
