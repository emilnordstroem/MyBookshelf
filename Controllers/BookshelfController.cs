using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.Controllers
{
	public class BookshelfController : Controller
	{
		public IActionResult Bookshelf()
		{
			return View();
		}

	}
}
