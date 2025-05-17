using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers
{
	public class AboutUsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
