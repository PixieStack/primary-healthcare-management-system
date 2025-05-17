using CodeMed.Areas.Identity.Data;
using CodeMed.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeMed.Controllers
{
    public class PrenatalCareController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult About()
        {
            return View();
        }
        public IActionResult HealthAssessment()
        {
            return View();
        }
        public IActionResult HealthEvaluation()
        {
            return View();
        }

        public IActionResult Declaration()
        {
            return View();
        }
        public IActionResult CounselingConsentForm()
        {
            return View();
        }

        public IActionResult CounselingMentalAssessment()
        {
            return View();
        }

        public IActionResult HealthSurvey()
        {
            return View();
        }

        public IActionResult MedicationConsent()
        {
            return View();
        }

    }
}
