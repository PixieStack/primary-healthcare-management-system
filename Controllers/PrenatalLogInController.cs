using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CodeMed.Areas.Identity.Data;

namespace CodeMed.Controllers
{
    public class PrenatalLogInController : Controller
    {
        private readonly SignInManager<CodeMedUser> _signInManager;

        public PrenatalLogInController(SignInManager<CodeMedUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        

        
    }
}
