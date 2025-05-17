using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers
{
    public class VaccinationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
