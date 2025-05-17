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
using CodeMed.Models.chronic;
using CodeMed.Models.vaccines;

namespace CodeMed.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public DoctorsController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        //REPORTS

       
        public IActionResult VaccinationHistory()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_VaccinationHistory", connection))
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

        public IActionResult VaccinationImmunization()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_ImmunizationReport", connection))
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

        public IActionResult VaccineUsage()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_VaccineUsage", connection))
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
        //CHRONIC MEDICATION DOCTORS
        public IActionResult ChronicIndex()
        {
            return View();
        }
        public IActionResult ChronicPrescribeMedication()
        {
            return View();
        }
        public IActionResult ChronicViewPatientReport()
        {
            return View();
        }
        public IActionResult ChronicMonitorProgress()
        {
            return View();
        }


        //VACCINATIONS DOCTORS
        public IActionResult VaccinationsIndex()
        {
            return View();
        }

        public IActionResult VaccinationAdminister()
        {
            GetPatients();
            VaccinationAdminister Date = new VaccinationAdminister()
            {
                VaccineDate = DateTime.Now,
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VaccinationAdminister(VaccinationAdminister vaccinationAdminister)
        {
            if (ModelState.IsValid)
            {
                _db.vaccinationAdministers.Add(vaccinationAdminister);
                _db.SaveChanges();
                TempData["success"] = "vaccination Administer saved successfully";
                return RedirectToAction("VaccinationAdminister");
            }
            return View(vaccinationAdminister);
        }


        public IActionResult VaccinationImmunizations()
        {
            GetPatients();
            VaccinationImmunizations Date = new VaccinationImmunizations()
            {
                VaccinationDate = DateTime.Now,
            };

            VaccinationImmunizations Next_Date = new VaccinationImmunizations()
            {
                NextVaccinationDate = DateTime.Now,
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VaccinationImmunizations(VaccinationImmunizations vaccinationImmunizations)
        {
            if (ModelState.IsValid)
            {
                _db.vaccinationImmunizations.Add(vaccinationImmunizations);
                _db.SaveChanges();
                TempData["success"] = "Vaccination Immunizationssaved successfully";
                return RedirectToAction("VaccinationImmunizations");
            }
            return View(vaccinationImmunizations);
        }

        public IActionResult Vaccinations()
        {
            GetPatients();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vaccinations(Vaccinations vaccinations)
        {
            if (ModelState.IsValid)
            {
                _db.vaccinations.Add(vaccinations);
                _db.SaveChanges();
                TempData["success"] = "Vaccination saved successfully";
                return RedirectToAction("Vaccinations");
            }
            return View(vaccinations);
        }
        public IActionResult VaccinationTravelMedicine()
        {
            GetPatients();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VaccinationTravelMedicine(VaccinationTravelMedicine vaccinationTravel)
        {
            if (ModelState.IsValid)
            {
                _db.travelMedicines.Add(vaccinationTravel);
                _db.SaveChanges();
                TempData["success"] = "Travel Vaccination ssaved successfully";
                return RedirectToAction("VaccinationTravelMedicine");
            }
            return View(vaccinationTravel);
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
        public ActionResult VaccineUsageRate()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_VaccineUsageRate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Get the lowest and highest usage counts
                    var lowestUsageCount = dataTable.Rows.Cast<DataRow>().Min(row => (int)row["UsageCount"]);
                    var highestUsageCount = dataTable.Rows.Cast<DataRow>().Max(row => (int)row["UsageCount"]);

                    // Create a model to pass to the view
                    var model = new VaccineUsageRateModel
                    {
                        DataTable = dataTable,
                        LowestUsageCount = lowestUsageCount,
                        HighestUsageCount = highestUsageCount
                    };

                    return View(model); // Pass the model to the view
                }
            }
        }


        public IActionResult DoctorPatient()
        {
            return View();

        }

        public IActionResult ImmunizationsAge()
        {
            // Define the age groups you want to filter by (adjust the values as needed)
            int ageGroup1 = 0; // Under 1 year
            int ageGroup2 = 10; // 1-10 years

            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_AgeImmunizations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    command.Parameters.Add(new SqlParameter("@AgeGroup1", ageGroup1));
                    command.Parameters.Add(new SqlParameter("@AgeGroup2", ageGroup2));

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to pass to the view
                    var model = new ImmuzationAge
                    {
                        DataTable = dataTable
                    };

                    return View(model); // Pass the model to the view
                }
            }
        }

        public ActionResult AgeImmunizations()
        {
            // Define placeholders for age groups
            int ageGroup1 = 1; // Replace with the desired values
            int ageGroup2 = 5; // Replace with the desired values

            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_AgeImmunizations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for age groups
                    command.Parameters.AddWithValue("@AgeGroup1", ageGroup1);
                    command.Parameters.AddWithValue("@AgeGroup2", ageGroup2);

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to pass to the view
                    var model = new ImmuzationAge
                    {
                        DataTable = dataTable
                    };

                    return View(model); // Pass the model to the view
                }
            }
        }


        public ActionResult ImmunizationGeo()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_ImmunizationGeographic", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to pass to the view
                    var model = new ImmunizationGeo
                    {
                        DataTable = dataTable
                    };

                    return View(model); // Pass the model to the view
                }
            }
        }



        public ActionResult VaccintaionGeo()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_VaccineGeographic", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Create a model to pass to the view
                    var model = new vaccineGeo
                    {
                        DataTable = dataTable
                    };

                    return View(model); // Pass the model to the view
                }
            }
        }

    }
}
