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
    public class AdministratorsController : Controller
    {
        //PRENATAL CARE ADMINISTRATORS
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<CodeMedUser> _signInManager;
        private readonly UserManager<CodeMedUser> _userManager;

        public AdministratorsController(IConfiguration configuration, ApplicationDbContext db, SignInManager<CodeMedUser> signInManager, UserManager<CodeMedUser> userManager)
        {
            _configuration = configuration;
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult PrenatalIndex()
        {
            return View();
        }
        public IActionResult PrenatalAbout()
        {
            return View();
        }
        public IActionResult PrenatalReport()
        {
            return View();
        }
        public IActionResult UpdateAppointments(int? ID)
        {
            GetPatients();
            GetDoctors();
            GetNurses();
            GetCounsellors();
            GetObstetrician();

            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            var Appointment = _db.appointments.Find(ID);

            if (Appointment == null)
            {
                return NotFound();
            }
            return View(Appointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAppointments(AppointmentRequest appointment)
        {
            if (ModelState.IsValid)
            {
                _db.appointments.Update(appointment);
                _db.SaveChanges();
                TempData["success"] = "Appointment updated successfully";
                return RedirectToAction("UpdateAppointments");
            }
            return View(appointment);
        }
        public IActionResult DeleteAppointments(int? id)
        {
            GetPatients();
            GetDoctors();
            GetNurses();
            GetCounsellors();
            GetObstetrician();
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var appointment = _db.appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAppointmentsPost(int? id)
        {
            var appointment = _db.appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _db.appointments.Remove(appointment);
            _db.SaveChanges();
            TempData["success"] = "Appointment deleted successfully";
            return RedirectToAction("PrenatalManageAppointments");

        }
        public IActionResult PrenatalManageAppointments()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_PatientBooking", connection))
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
                            Id = row["Id"],
                            FullName = row["FullName"]
                        }).ToList();
                    }
                }
            }

            return View();
        }

        public IActionResult PrenatalScheduleAppointments()
        {
            AppointmentRequest schedule = new AppointmentRequest()
            {
                PreferredDate = DateTime.Now,
            };
            return View();
        }

        public IActionResult PrenatalManageUsers()
        {
            var users = _db.Users.ToList(); // Adjust this query as needed

            return View(users);
        }

        public IActionResult PrenatalViewLogs()
        {
            return View();
        }

        

        public IActionResult GetAllUsers()
        {
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
        }

        public IActionResult GetAllPatients()
        {
            AllPatients();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
        }
        public IActionResult GetAllNurses()
        {
            AllNurses();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
        }
        public IActionResult GetAllDoctors()
        {
            AllDoctors();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
        }
        public IActionResult GetAllAdmins()
        {
            AllAdmins();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View();
        }


        public IActionResult GetAllCounsellors()
        {
            AllCounsellors();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
        }
        public IActionResult GetAllObstetrician()
        {
            AllObstetrician();
            var users = _db.Users.ToList(); // Adjust this query as needed
            string reportContent = GenerateReport(users);

            ViewBag.ReportContent = reportContent;

            return View(users);
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

        public IActionResult DeleteUser(string userId)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_DeleteUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add a parameter for the user's ID
                    command.Parameters.AddWithValue("Id", userId);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index"); // Redirect to a different action after deletion, if needed
        }

        private string GenerateReport(List<CodeMedUser> users)
        {
            StringBuilder report = new StringBuilder();

            // Add headers to the report
            report.AppendLine("Administrators Report");
            report.AppendLine("========================");
            report.AppendLine("Title\t\tFirst Name\t\tLast Name\t\tGender\t\t\tEmail\t\t\t\t\tPhone Number\t\t\tRole");
            report.AppendLine("=====\t\t==========\t\t=========\t\t======\t\t\t=====\t\t\t\t\t============\t\t\t=====");

            // Add user data to the report
            foreach (var user in users)
            {
                report.AppendLine($"{user.Title}\t\t{user.FirstName}\t\t\t{user.LastName}\t\t\t{user.Gender}\t\t\t{user.Email}\t\t\t{user.Phone_Number}\t\t\t{user.Role}");
            }

            return report.ToString();
        }
        public IActionResult DownloadAdminsReport()
        {
            var users = _db.Users.ToList(); // Adjust this query as needed

            // Generate the report content as a string
            string reportContent = GenerateReport(users);

            // Convert the report content to bytes
            byte[] reportBytes = Encoding.UTF8.GetBytes(reportContent);

            // Return the file as a downloadable attachment
            return File(reportBytes, "text/plain", "users_report.txt");
        }

        // GET: Administrators/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Administrators/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                TempData["success"] = "User deleted successfully";
                return RedirectToAction("PrenatalManageUsers"); // Redirect to a different action, e.g., "Index"
            }

            // Handle errors if the deletion was not successful
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }
        // Update GET Method
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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

        // Update POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CodeMedUser updatedUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(updatedUser.Id);
                if (user == null)
                {
                    return NotFound();
                }

                // Update user properties with the values from 'updatedUser'.
                user.Title = updatedUser.Title;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Phone_Number = updatedUser.Phone_Number;
                user.Street_Address = updatedUser.Street_Address;
                user.Surburb = updatedUser.Surburb;
                user.City = updatedUser.City;
                user.Province = updatedUser.Province;
                user.NextOfKinName = updatedUser.NextOfKinName;
                user.NextOfKinRelationship = updatedUser.NextOfKinRelationship;
                user.NextOfKinPhone = updatedUser.NextOfKinPhone;
                user.NextOfKinEmail = updatedUser.NextOfKinEmail;
                user.Gender = updatedUser.Gender;
                user.Postal_Code = updatedUser.Postal_Code;
                user.Occupation = updatedUser.NextOfKinEmail;
                user.Citizenship = updatedUser.NextOfKinEmail;
                user.Role = updatedUser.Role;
                user.PHC_Role = updatedUser.PHC_Role;

                // Save the updated user data.
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["success"] = "User updated successfully";
                    return RedirectToAction("PrenatalManageUsers"); // Redirect to a different action, e.g., "Index"
                }

                // Handle errors if the update was not successful
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // If the ModelState is not valid or the update fails, return to the edit view with validation errors.
            return View(updatedUser);
        }



        //WALK-IN ADMINISTRATORS


        //FAMILY PLANNING ADMINISTRATORS


        //COUNSELLING ADMINISTRATORS


        //CHRONIC MEDICATION ADMINISTRATORS


        //VACCINATIONS ADMINISTRATORS
    }
}
