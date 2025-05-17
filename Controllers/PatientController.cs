using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CodeMed.Areas.Identity.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using CodeMed.Models.vaccines;
using Microsoft.Extensions.Hosting;
using System.Net.Mime;
using CodeMed.Models.Prenatal.Doctor;
using CodeMed.Models.chronic;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeMed.Controllers
{
    public class PatientController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<CodeMedUser> _userManager;

        public PatientController(IConfiguration configuration, ApplicationDbContext db, UserManager<CodeMedUser> userManager)
        {
            _configuration = configuration;
            _db = db;
            _userManager = userManager;
        }

        //PRENATAL CARE PATIENT
        public IActionResult PrenatalIndex()
        {
            return View();
        }
        public IActionResult ChronicIndex()
        {
            return View();
        }

        public IActionResult PatientManageProfile()
        {
            return View();
        }

        public IActionResult PatientAdvice()
        {
            return View();
        }
        public IActionResult PatientTrackProgress()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_PrenatalTracking", connection))
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

        public IActionResult PatientHistory()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_PrenatalTracking", connection))
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



        //WALK-IN PATIENT


        //FAMILY PLANNING PATIENT


        //COUNSELLING PATIENT
        public IActionResult CounsellingIndex()
        {
            return View();
        }
        public IActionResult CounsellingProgressTracking()
        {
            return View();
        }
        public IActionResult CounsellingViewCalender()
        {
            return View();
        }
        public IActionResult CounsellingSelfAssessment()
        {
            return View();
        }
        public IActionResult CounsellingGoalSetting()
        {
            return View();
        }
        public IActionResult CounsellingAccessResources()
        {
            return View();
        }

        //CHRONIC MEDICATION PATIENT
        public IActionResult ChronicMedicationHistory()
        {
            return View();
        }


        //VACCINATIONS PATIENT
        public IActionResult VaccinationsIndex()
        {
            return View();
        }
        public IActionResult VaccinationReportAdverseReactions()
        {
            GetPatients();
            return View();
        }
        public IActionResult VaccinationForum()
        {
            Forum();
            return View();
        }
        public IActionResult Add_Forum()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add_Forum(Forum forum)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // Use _userManager instead of userManager

                if (user != null)
                {
                    forum.PatientName = user.Id; // Set the PatientId based on the currently logged-in user

                    _db.forum.Add(forum);
                    _db.SaveChanges();
                    TempData["success"] = "Post saved successfully";
                    return RedirectToAction("VaccinationForum");
                }
                else
                {
                    // Handle the case where the user is not found or not logged in
                    // Redirect to a login page or display an error message
                }
            }

            return View(forum); // Handle validation errors and redisplay the form
        }
        public IActionResult Add_Forum_Reply()
        {
            GetPostId();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add_Forum_Reply(ForumReplies replies)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    replies.PatientId = user.Id;

                    // Assuming replies.PostId is set in the form or from the route parameter
                    _db.replies.Add(new ForumReplies
                    {
                        PatientId = replies.PatientId,
                        Reply = replies.Reply,
                        Likes = replies.Likes,
                        Dislikes = replies.Dislikes,
                        PostId = replies.PostId // Set PostId directly
                    });

                    _db.SaveChanges();
                    TempData["success"] = "Post saved successfully";
                    return RedirectToAction("VaccinationForum"); // Redirect to the forum view or any other action
                }
                else
                {
                    // Handle the case where the user is not found or not logged in
                    // Redirect to a login page or display an error message
                }
            }

            return View(replies); // Handle validation errors and redisplay the form
        }




        public IActionResult VaccinationReport()
        {
            return View();
        }
        public IActionResult VaccinationExternalInfos()
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
        public IActionResult VaccinationForumIndex()
        {
            return View();
        }

        public IActionResult Forum()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_ForumPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    return View(dataTable); // Pass the DataTable directly to the view
                }
            }
        }


        public IActionResult Forumreplies()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_ForumPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    return View(dataTable); // Pass the DataTable directly to the view
                }
            }
        }


        public IActionResult Review()
        {
            return View();

        }
        public IActionResult ConsentForm()
        {
            return View();

        }

        public IActionResult Certificate()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_VaccineCert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Retrieve the Patient ID from session data
                    string patientId = HttpContext.Session.GetString("Id");

                    if (!string.IsNullOrEmpty(patientId))
                    {
                        // Use patientId to retrieve the value you want to pass as a parameter
                        command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return View(dataTable);
                        }
                    }
                    else
                    {
                        // Handle the case where the patientId is missing or empty
                        // You can return an error message or redirect the user to a different page.
                        // For example:
                        return RedirectToAction("Error");
                    }
                }
            }
        }
        public IActionResult DownloadCertificate(int certificateId)
        {
            // Fetch certificate details based on certificateId
            // Generate the certificate content (e.g., HTML content)
            string certificateContent = GetCertificateContent(certificateId);

            // Set the appropriate headers for downloading
            var contentDisposition = new ContentDisposition
            {
                FileName = $"Certificate_{certificateId}.html",
                Inline = false,
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            // Return the certificate content as a file
            return Content(certificateContent, "text/html");
        }

        // Example method to generate certificate content (replace with your logic)
        private string GetCertificateContent(int certificateId)
        {
            // Logic to generate certificate content based on certificateId
            // You can use a Razor view or any other method to create HTML content
            // Replace this with your actual logic to generate the certificate HTML
            string certificateContent = "<html><head><title>Certificate</title></head><body><h1>Certificate Content</h1></body></html>";

            return certificateContent;
        }

        public IActionResult Reviews()
        {
            ReviewsLists();
            return View();
        }
        public IActionResult Add_Reviews()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add_Reviews(reviews reviews)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the current user's ID
                string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Associate the user ID with the review
                reviews.Patient = currentUserId;

                // Validate the review content and star ratings
                if (!string.IsNullOrWhiteSpace(reviews.review) &&
                    (reviews.One_stars.HasValue || reviews.Two_stars.HasValue || reviews.Three_stars.HasValue || reviews.Four_stars.HasValue || reviews.Five_stars.HasValue))
                {
                    // Add the review to the database
                    _db.reviews.Add(reviews);
                    _db.SaveChanges();
                    TempData["success"] = "Review successfully uploaded";
                    return RedirectToAction("Reviews");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Review content and star ratings are required.");
                }
            }

            return View(reviews);
        }
        public IActionResult ReviewsLists()
        {
            // Create a connection to your database using the configuration
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("sp_reviews", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create a data adapter to fetch the data
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();

                    // Fill the data table with the results of the stored procedure
                    adapter.Fill(dataTable);

                    return View(dataTable); // Pass the DataTable directly to the view
                }
            }
        }
        public IActionResult GetPostId()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Change to your connection string key
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_ForumPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ViewBag.Replies = dataTable.AsEnumerable().Select(row => new
                        {
                            Id = row["Id"].ToString()
                        }).ToList();
                    }
                }
            }

            return View();
        }

    }
}
