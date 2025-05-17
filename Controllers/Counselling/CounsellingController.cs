using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers.Counselling
{
    public class CounsellingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
