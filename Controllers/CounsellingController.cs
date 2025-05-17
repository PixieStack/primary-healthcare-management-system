using CodeMed.Areas.Identity.Data;
using CodeMed.Models;
using CodeMed.Models.Prenatal.Counsellor;
using CodeMed.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Numerics;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CodeMed.Controllers
{
    public class CounsellingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public CounsellingController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //PRENATAL CARE COUNSELLING
        public IActionResult PrenatalIndex()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult PrenatalGrief()
        {
            GetPatients();
            Prenatal_Grief_Therapy Date = new Prenatal_Grief_Therapy()
            {
                Date = DateTime.Now,
            };

            Prenatal_Grief_Therapy Due_Date = new Prenatal_Grief_Therapy()
            {
                Due_Date = DateTime.Now,
            };
            return View(Date);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalGrief(Prenatal_Grief_Therapy grief)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Grief_Therapy.Add(grief);
                _db.SaveChanges();
                TempData["success"] = "Patient latest grief session saved successfully";
                return RedirectToAction("PrenatalGrief");
            }
            return View(grief);
        }

        public IActionResult PrenatalPostpartum()
        {
            GetPatients();
            Prenatal_Postpartum_Therapy Therapy_Date = new Prenatal_Postpartum_Therapy()
            {
                Therapy_Date = DateTime.Now,
            };

            return View(Therapy_Date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalPostpartum(Prenatal_Postpartum_Therapy postpartum)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Postpartum_Therapy.Add(postpartum);
                _db.SaveChanges();
                TempData["success"] = "Patient latest postpartum session saved successfully";
                return RedirectToAction("PrenatalPostpartum");
            }
            return View(postpartum);
        }

        public IActionResult PrenatalStress()
        {
            GetPatients();
            Prenatal_Stress_Therapy Therapy_Date = new Prenatal_Stress_Therapy()
            {
                Therapy_Date = DateTime.Now,
            };

            return View(Therapy_Date);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalStress(Prenatal_Stress_Therapy stress)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Stress_Therapy.Add(stress);
                _db.SaveChanges();
                TempData["success"] = "Patient latest stress session saved successfully";
                return RedirectToAction("PrenatalStress");
            }
            return View(stress);
        }
        public IActionResult PrenatalTeenMoms()
        {
            GetPatients();
            Prenatal_TeenMoms_Therapy Therapy_Date = new Prenatal_TeenMoms_Therapy()
            {
                Therapy_Date = DateTime.Now,
            };

            return View(Therapy_Date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalTeenMoms(Prenatal_TeenMoms_Therapy teenMoms)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_TeenMoms_Therapy.Add(teenMoms);
                _db.SaveChanges();
                TempData["success"] = "Patient latest therapy session saved successfully";
                return RedirectToAction("PrenatalTeenMoms");
            }
            return View(teenMoms);
        }

        //WALK-IN COUNSELLING


        //FAMILY PLANNING COUNSELLING


        //COUNSELLING COUNSELLING
        public IActionResult CounsellingIndex()
        {
            return View();
        }
        public IActionResult CounsellingConsent()
        {
            return View();
        }
        public IActionResult CounsellingViewAppointments()
        {
            return View();
        }
        public IActionResult CounsellingProgressTracking()
        {
            return View();
        }
        public IActionResult CousellingResources()
        {
            return View();
        }
        public IActionResult CounsellingMentalAssessement()
        {
            return View();
        }

        //CHRONIC MEDICATION COUNSELLING

        public IActionResult ChronicIndex()
        {
            return View();
        }

        //VACCINATIONS COUNSELLING
        public IActionResult GetPatients()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_Patients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Patients = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"].ToString(),
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
    }
}
