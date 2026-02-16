using Microsoft.AspNetCore.Mvc;
using MyBookshelf.Data;

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
