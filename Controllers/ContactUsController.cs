using CodeMed.Areas.Identity.Data;
using CodeMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContactUsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _db.contactUs.Add(contact);
                _db.SaveChanges();
                TempData["success"] = "Message sent successfully";
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}