using CodeMed.Areas.Identity.Pages.Account;
using CodeMed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Numerics;
using System;
using System.Linq;
using CodeMed.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using CodeMed.Models.Prenatal.Doctor;
using CodeMed.Models.chronic;

namespace CodeMed.Controllers
{
    public class ChronicMedicationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public ChronicMedicationController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PrescriptionsConditions()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_medicalPrescriptionsConditions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the Obstetrician ID from session data
                    string ObstetricianId = HttpContext.Session.GetString("Id");

                    if (!string.IsNullOrEmpty(ObstetricianId))
                    {
                        // Use ObstetricianId to retrieve the value you want to pass as a parameter
                        string concatenatedName = $"{HttpContext.Session.GetString("FirstName")} {HttpContext.Session.GetString("LastName")}";

                        // Check if the concatenatedName is not null or empty before adding it as a parameter
                        if (!string.IsNullOrEmpty(concatenatedName))
                        {
                            command.Parameters.Add(new SqlParameter("@Doctor", concatenatedName));
                        }
                        else
                        {
                            // Handle the case where the name is missing or empty
                            // You can return a placeholder value for PatientName or redirect the user to a different page.
                            // For example:
                            string placeholderPatientName = "Name Not Found";
                            return View(placeholderPatientName);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return View(dataTable);
                        }
                    }
                    else
                    {
                        // Handle the case where the ObstetricianId is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        return RedirectToAction("Error");
                    }
                }
            }
        }

        public IActionResult TotalPresc()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_doctorTotalPresc", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the Obstetrician ID from session data
                    string ObstetricianId = HttpContext.Session.GetString("Id");

                    if (!string.IsNullOrEmpty(ObstetricianId))
                    {
                        // Use ObstetricianId to retrieve the value you want to pass as a parameter
                        string concatenatedName = $"{HttpContext.Session.GetString("FirstName")} {HttpContext.Session.GetString("LastName")}";

                        // Check if the concatenatedName is not null or empty before adding it as a parameter
                        if (!string.IsNullOrEmpty(concatenatedName))
                        {
                            command.Parameters.Add(new SqlParameter("@Doctor", concatenatedName));
                        }
                        else
                        {
                            // Handle the case where the name is missing or empty
                            // You can return a placeholder value for PatientName or redirect the user to a different page.
                            // For example:
                            string placeholderPatientName = "Name Not Found";
                            return View(placeholderPatientName);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return View(dataTable);
                        }
                    }
                    else
                    {
                        // Handle the case where the ObstetricianId is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        return RedirectToAction("Error");
                    }
                }
            }
        }

        public IActionResult medicalPrescriptions()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_medicalPrescriptions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the Obstetrician ID from session data
                    string ObstetricianId = HttpContext.Session.GetString("Id");

                    if (!string.IsNullOrEmpty(ObstetricianId))
                    {
                        // Use ObstetricianId to retrieve the value you want to pass as a parameter
                        string concatenatedName = $"{HttpContext.Session.GetString("FirstName")} {HttpContext.Session.GetString("LastName")}";

                        // Check if the concatenatedName is not null or empty before adding it as a parameter
                        if (!string.IsNullOrEmpty(concatenatedName))
                        {
                            command.Parameters.Add(new SqlParameter("@Doctor", concatenatedName));
                        }
                        else
                        {
                            // Handle the case where the name is missing or empty
                            // You can return a placeholder value for PatientName or redirect the user to a different page.
                            // For example:
                            string placeholderPatientName = "Name Not Found";
                            return View(placeholderPatientName);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return View(dataTable);
                        }
                    }
                    else
                    {
                        // Handle the case where the ObstetricianId is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        return RedirectToAction("Error");
                    }
                }
            }
        }

        public IActionResult MedicationDosageAdjustment()
        {
            GetPatients();
            MedicationDosageAdjustment Date = new MedicationDosageAdjustment()
            {
                Date = DateTime.Now,
            };
            return View(Date);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicationDosageAdjustment(MedicationDosageAdjustment adjustment)
        {
            if (ModelState.IsValid)
            {
                _db.adjustments.Add(adjustment);
                _db.SaveChanges();
                TempData["success"] = "Medication Dosage Adjustment saved successfully";
                return RedirectToAction("MedicationDosageAdjustment");
            }
            return View(adjustment);
        }
        public IActionResult MedicationFeedback()
        {
            GetPatients();
            MedicationFeedback Date = new MedicationFeedback()
            {
                Date = DateTime.Now,
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicationFeedback(MedicationFeedback medicationFeedback)
        {
            if (ModelState.IsValid)
            {
                _db.feedbacks.Add(medicationFeedback);
                _db.SaveChanges();
                TempData["success"] = "Medication Feedback saved successfully";
                return RedirectToAction("MedicationFeedback");
            }
            return View(medicationFeedback);
        }
        public IActionResult MedicationHistory()
        {
            GetPatients();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicationHistory(MedicationHistory medicationHistory)
        {
            if (ModelState.IsValid)
            {
                _db.medicationHistories.Add(medicationHistory);
                _db.SaveChanges();
                TempData["success"] = "Medication History saved successfully";
                return RedirectToAction("MedicationHistory");
            }
            return View(medicationHistory);
        }
        public IActionResult MedicationPrescription()
        {
            GetPatients();
            MedicationPrescription Date = new MedicationPrescription()
            {
                PrescriptionDate = DateTime.Now,
            };
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicationPrescription(MedicationPrescription medicationPrescription)
        {
            if (ModelState.IsValid)
            {
                _db.medicationPrescriptions.Add(medicationPrescription);
                _db.SaveChanges();
                TempData["success"] = "Medication Prescription saved successfully";
                return RedirectToAction("MedicationPrescription");
            }
            return View(medicationPrescription);
        }

        public IActionResult MedicationRefill()
        {
            GetPatients();
            MedicationRefill Date = new MedicationRefill()
            {
                RefillDate = DateTime.Now,
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicationRefill(MedicationRefill MedicationRefill)
        {
            if (ModelState.IsValid)
            {
                _db.medicationRefill.Add(MedicationRefill);
                _db.SaveChanges();
                TempData["success"] = "Medication Refill saved successfully";
                return RedirectToAction("MedicationRefill");
            }
            return View(MedicationRefill);
        }

        public IActionResult FAQs()
        {
            return View();
        }

        public IActionResult LearnMore()
        {
            return View();
        }
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
        public IActionResult ChronicMedsHistoryReport()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_ChronicMedsHistoryReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Report = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"].ToString(),
                            Doctor = row["Doctor"],
                            Patient = row["Patient"],
                            ChronicCondition = row["ChronicCondition"],
                            Allergies = row["Allergies"],
                            FamilyHistory = row["FamilyHistory"],
                            MedicationName = row["MedicationName"],
                            Dose = row["Dose"],
                            MedicationReason = row["MedicationReason"],
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult MostPrecribed()
        {
            return View();

        }

        public IActionResult PrescriptionAnalysis()
        {
            return View();

        }

        public IActionResult PatientMedication()
        {
            return View();

        }

        public IActionResult Performance()
        {
            return View();

        }

        public ActionResult MedicationReport()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_GetMeds", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to transfer the data
                    var model = new MedicationReportModel
                    {
                        DataTable = dataTable
                    };

                    return View(model);
                }
            }
        }
        
        public ActionResult MostPrescribed()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_MostPrescribed", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model of the correct type to transfer the data
                    var model = new MostPrescribedModel
                    {
                        DataTable = dataTable
                    };

                    return View(model);
                }
            }
        }
        public ActionResult DoctorTotalPrescriptions()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_medicalPrescriptionsConditions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to transfer the data
                    var model = new DoctorTotalPrescModel
                    {
                        DataTable = dataTable
                    };

                    return View(model);
                }
            }
        }

        public IActionResult MedicationPrescriptionHistory()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_medicalPrescriptions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the Doctor ID from session data
                    string doctorId = HttpContext.Session.GetString("Id");

                    if (!string.IsNullOrEmpty(doctorId))
                    {
                        // Use doctorId to retrieve the value you want to pass as a parameter
                        string concatenatedName = $"{HttpContext.Session.GetString("FirstName")} {HttpContext.Session.GetString("LastName")}";

                        // Check if the concatenatedName is not null or empty before adding it as a parameter
                        if (!string.IsNullOrEmpty(concatenatedName))
                        {
                            command.Parameters.Add(new SqlParameter("@Doctor", concatenatedName));
                        }
                        else
                        {
                            // Handle the case where the name is missing or empty
                            // You can return a placeholder value for PatientName or redirect the user to a different page.
                            // For example:
                            string placeholderPatientName = "Name Not Found";
                            return View(placeholderPatientName);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return View(dataTable);
                        }
                    }
                    else
                    {
                        // Handle the case where the doctorId is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        return RedirectToAction("Error");
                    }
                }
            }
        }

    }
}
