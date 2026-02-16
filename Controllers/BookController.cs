using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		[HttpGet("books")]
		public IActionResult Index()
		{
			return 
		}
	}
}
