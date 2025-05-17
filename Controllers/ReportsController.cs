using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using CodeMed.Areas.Identity.Pages.Account;
using CodeMed.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Numerics;


namespace CodeMed.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllUsers()
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
                            Id = row["Id"],
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetAllPatints()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_AllPatients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Patients = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetAllDoctors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_allDoctors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Doctors = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetAllNurses()
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
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetAllCounsellors()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_AllCounsellors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Counsellors = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult GetAllAdmins()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_AllAdmins", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Admins = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"],
                            FullName = row["FullName"],
                            Gender = row["Gender"],
                            Citizenship = row["Citizenship"],
                            Phone_Number = row["Phone_Number"],
                            Email = row["Email"],
                            Street_Address = row["Street_Address"],
                            Surburb = row["Surburb"],
                            City = row["City"],
                            Province = row["Province"],
                            Postal_Code = row["Postal_Code"]

                        }).ToList();
                    }
                }
            }

            return View();
        }
    }
}
