using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers
{
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
