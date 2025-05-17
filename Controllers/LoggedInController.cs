using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CodeMed.Controllers
{
    public class LoggedInController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Role()
        {
            var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
            var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

            switch (role)
            {
                case "Patient":
                    return RedirectToAction("PrenatalIndex", "Patient");
                case "PHC Worker":
                    switch (phcRole)
                    {
                        case "Obstetrician":
                            return RedirectToAction("PrenatalIndex", "Obstetrician");
                        case "Doctor":
                            return RedirectToAction("Index", "LoggedIn");
                        case "Nurse":
                            return RedirectToAction("Index", "LoggedIn");
                        case "Counsellor":
                            return RedirectToAction("PrenatalIndex", "Counselling");
                        default:
                            return View();
                    }
                default:
                    return View();
            }
        }

        public IActionResult Chronic()
        {
            var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
            var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

            switch (role)
            {
                case "Patient":
                    return RedirectToAction("ChronicIndex", "Patient");
                case "PHC Worker":
                    switch (phcRole)
                    {
                        case "Doctor":
                            return RedirectToAction("ChronicIndex", "Doctors");
                        case "Nurse":
                            return RedirectToAction("ChronicIndex", "Nurse");
                        case "Counsellor":
                            return RedirectToAction("ChronicIndex", "Counselling");
                        default:
                            return View();
                    }
                default:
                    return View();
            }
        }

        public IActionResult Counselling()
        {
            var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
            var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

            switch (role)
            {
                case "Patient":
                    return RedirectToAction("CounsellingIndex", "Patient");
                case "PHC Worker":
                    switch (phcRole)
                    {
                        case "Doctor":
                            return RedirectToAction("CounsellingIndex", "Doctors");
                        case "Nurse":
                            return RedirectToAction("CounsellingIndex", "Nurse");
                        case "Counsellor":
                            return RedirectToAction("CounsellingIndex", "Counselling");
                        default:
                            return View();
                    }
                default:
                    return View();
            }
        }

        public IActionResult Vaccination()
        {
            var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
            var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

            switch (role)
            {
                case "Patient":
                    return RedirectToAction("VaccinationsIndex", "Patient");
                case "PHC Worker":
                    switch (phcRole)
                    {
                        case "Doctor":
                            return RedirectToAction("VaccinationsIndex", "Doctors");
                        case "Nurse":
                            return RedirectToAction("VaccinationIndex", "Nurse");
                        case "Counsellor":
                            return RedirectToAction("VaccinationIndex", "Counselling");
                        default:
                            return View();
                    }
                default:
                    return View();
            }
        }

        //public IActionResult Walkin()
        //{
        //    var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
        //    var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

        //    switch (role)
        //    {
        //        case "Patient":
        //            return RedirectToAction("WalkinIndex", "Patient");
        //        case "Administrator":
        //            return RedirectToAction("WalkinIndex", "Administrators");
        //        case "PHC Worker":
        //            switch (phcRole)
        //            {
        //                case "Doctor":
        //                    return RedirectToAction("WalkinIndex", "Doctors");
        //                case "Nurse":
        //                    return RedirectToAction("WalkinIndex", "Nurse");
        //                case "Counsellor":
        //                    return RedirectToAction("WalkinIndex", "Counselling");
        //                default:
        //                    return View();
        //            } 
        //        default:
        //            return View();
        //    }
        //}

        public IActionResult Family()
        {
            var role = _httpContextAccessor.HttpContext.Session.GetString("Role");
            var phcRole = _httpContextAccessor.HttpContext.Session.GetString("PHC_Role");

            switch (role)
            {
                case "Patient":
                    return RedirectToAction("FamilyIndex", "Patient");
                case "PHC Worker":
                    switch (phcRole)
                    {
                        case "Doctor":
                            return RedirectToAction("FamilyIndex", "Doctors");
                        case "Nurse":
                            return RedirectToAction("FamilyIndex", "Nurse");
                        case "Counsellor":
                            return RedirectToAction("FamilyIndex", "Counselling");
                        default:
                            return View();
                    }
                default:
                    return View();
            }
        }
    }
}
