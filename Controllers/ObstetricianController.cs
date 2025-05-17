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

namespace CodeMed.Controllers
{
    public class ObstetricianController : Controller
	{
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public ObstetricianController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        //PRENATAL CARE DOCTORS
        public IActionResult PrenatalIndex()
		{
			return View();
		}

        public IActionResult BabyGrowth()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_BabyGrowth", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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

        public IActionResult PrenatalViewPatientList()
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetDoctorPatient", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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


        public IActionResult GetPatientByMedication()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetPatientByMedication", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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

        public IActionResult GetPatientByTrimester()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetPatientByTrimester", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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

        public IActionResult Patientmedication()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_Patientmedication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the user's ID from session data
                    string userId = HttpContext.Session.GetString("Id");

                    // Check if the userId is not null or empty before adding it as a parameter
                    if (!string.IsNullOrEmpty(userId))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", userId));
                    }
                    else
                    {
                        // Handle the case where the user's ID is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        // return RedirectToAction("Error");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return View(dataTable);
                    }
                }
            }
        }

        public IActionResult PatientTest()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_PatientTest", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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

        public IActionResult ReferralAnalysis()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_ReferralAnalysis", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return View(dataTable);
                    }
                }
            }
        }

        public IActionResult ReferralAnalysisHospital()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_ReferralAnalysisHospital", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return View(dataTable);
                    }
                }
            }
        }

        public IActionResult ReferralByObstetrician()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_ReferralByObstetrician", connection))
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
                            command.Parameters.Add(new SqlParameter("@Obstetrician", concatenatedName));
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

        public IActionResult PrenatalMedication()
		{
			GetPatients();

            Prenatal_Obstetrician_Medication Start_Date = new Prenatal_Obstetrician_Medication()
			{
				Start_Date = DateTime.Now,
			};

            Prenatal_Obstetrician_Medication End_Date = new Prenatal_Obstetrician_Medication()
			{
				Start_Date = DateTime.Now,
			};
			return View(Start_Date);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalMedication(Prenatal_Obstetrician_Medication medication)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Obstetrician_Medication.Add(medication);
                _db.SaveChanges();
                TempData["success"] = "Patient latest medication saved successfully";
                return RedirectToAction("PrenatalMedication");
            }
            return View(medication);
        }


        public IActionResult PrenatalMonitorProgress()
        {
            GetPatients();
            Prenatal_Obstetrician_Monitoring Date = new Prenatal_Obstetrician_Monitoring
            {
                Date = DateTime.Now
            };
            return View(Date); // Pass the model to the view for user input
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalMonitorProgress(Prenatal_Obstetrician_Monitoring monitoring)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Obstetrician_Monitoring.Add(monitoring);
                _db.SaveChanges();
                TempData["success"] = "Patient latest monitoring saved successfully";
                return RedirectToAction("PrenatalMonitorProgress");
            }
            return View(monitoring); // Return the model with validation errors to the view
        }

        public IActionResult PrenatalPatientReferral()
		{
            GetPatients();
            Prenatal_Obstetrician_Referral Referral_Date = new Prenatal_Obstetrician_Referral
            {
                Referral_Date = DateTime.Now
            };
            return View(Referral_Date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrenatalPatientReferral(Prenatal_Obstetrician_Referral referral)
        {
            if (ModelState.IsValid)
            {
                _db.Prenatal_Obstetrician_Referral.Add(referral);
                _db.SaveChanges();
                TempData["success"] = "Patient referral saved successfully";
                return RedirectToAction("PrenatalPatientReferral");
            }
            return View(referral);
        }



        public IActionResult GetPatients()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); 
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
        public IActionResult PatientsonMedication()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_PatientsonMedication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.PatientsonMedication = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            Obstetrician = row["Obstetrician"],
                            Patient = row["Patient"],
                            Trimester = row["Trimester"],
                            Medication_Name = row["Medication_Name"],
                            Dose_Period = row["Dose_Period"],
                            Start_Date = row["Start_Date"],
                            End_Date = row["End_Date"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult PatientsMonitoring()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_PatientsMonitoring", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.PatientsMonitoring = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            Obstetrician = row["Obstetrician"],
                            Patient = row["Patient"],
                            Blood_Pressure = row["Blood_Pressure"],
                            Date = row["Date"],
                            Heart_Rate = row["Heart_Rate"],
                            Temperature = row["Temperature"],
                            Weight = row["Weight"],
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult ReferredPatients()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_ReferredPatients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.ReferredPatients = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            Obstetrician = row["Obstetrician"],
                            Patient = row["Patient"],
                            Province = row["Province"],
                            Hospital = row["Hospital"],
                            Referral_Date = row["Referral_Date"],
                            Symptoms = row["Symptoms"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
        public class CombinedViewModel
        {
            public List<CodeMed.Areas.Identity.Data.CodeMedUser> Users { get; set; }
            public CodeMed.Models.Prenatal.Doctor.Prenatal_Obstetrician_Medication Medication { get; set; }
            public CodeMed.Models.Prenatal.Doctor.Prenatal_Obstetrician_Monitoring Monitoring { get; set; }
        }

    }
}
