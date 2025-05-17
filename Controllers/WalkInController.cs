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
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace CodeMed.Controllers
{
    public class WalkInController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<CodeMedUser> _signInManager;
        private readonly UserManager<CodeMedUser> _userManager;

        public WalkInController(IConfiguration configuration, ApplicationDbContext db, SignInManager<CodeMedUser> signInManager, UserManager<CodeMedUser> userManager)
        {
            _configuration = configuration;
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrenatalManageBooking()
        {
            GetPatients();
            GetDoctors();
            GetNurses();
            GetCounsellors();
            GetObstetrician();
            return View();
        }
        public IActionResult GetPatients()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_PatientBooking", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Patients = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            Patient = row["Patient"],
                            SelectedService = row["SelectedService"],
                            SelectedProviderType = row["SelectedProviderType"],
                            SelectedProviderId = row["SelectedProviderId"],
                            PreferredDate = row["PreferredDate"],
                            PreferredTime = row["PreferredTime"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
        public IActionResult AllAdmins()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllAdmins", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Admins = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
        public IActionResult AllPatients()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllPatients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Patients = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
        public IActionResult AllCounsellors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllCounsellors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Counsellor = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"],
                            PHC_Role = row["PHC_Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }
        public IActionResult AllDoctors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllDoctors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Doctors = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"],
                            PHC_Role = row["PHC_Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult AllUsers()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_AllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Users = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"],
                            PHC_Role = row["PHC_Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult AllNurses()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllNurses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Nurses = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"],
                            PHC_Role = row["PHC_Role"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult AllObstetrician()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_GetAllObstetrician", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Obstetrician = dataTable.AsEnumerable().Select(row => new
                        {
                            Title = row["Title"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            Gender = row["Gender"],
                            Email = row["Email"],
                            PhoneNumber = row["Phone_Number"],
                            Role = row["Role"],
                            PHC_Role = row["PHC_Role"]
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
