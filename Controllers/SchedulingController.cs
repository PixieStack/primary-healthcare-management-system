using CodeMed.Areas.Identity.Data;
using CodeMed.Areas.Identity.Pages.Account;
using CodeMed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Numerics;


namespace CodeMed.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public SchedulingController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public IActionResult Index()
        {
            GetPatients();
            GetDoctors();
            GetNurses();
            GetCounsellors();
            GetObstetrician();


            AppointmentRequest schedule = new AppointmentRequest()
            {
                PreferredDate = DateTime.Now
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AppointmentRequest schedule)
        {
            if (ModelState.IsValid)
            {
                _db.appointments.Add(schedule);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // There are validation errors
                // You can add error messages to ModelState if needed
                ModelState.AddModelError("SelectedProviderId", "Please select a valid provider.");
                // Return the view with validation errors
                return View(schedule);
            }
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
        public IActionResult GetDoctors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_Doctors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Doctors = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetNurses()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_Nurses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Nurses = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetCounsellors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_Counsellors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Counsellors = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetObstetrician()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_Obstetrician", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Obstetrician = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        
    }
}
