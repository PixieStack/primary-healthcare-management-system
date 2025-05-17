using CodeMed.Areas.Identity.Data;
using CodeMed.Models;
using CodeMed.Models.chronic;
using CodeMed.Models.Prenatal.Admin;
using CodeMed.Models.Prenatal.Counsellor;
using CodeMed.Models.Prenatal.Doctor;
using CodeMed.Models.Prenatal.Patient;
using CodeMed.Models.vaccines;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeMed.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<CodeMedUser>
    {
        //Prenatal Therapy
        public DbSet<Prenatal_Grief_Therapy> Prenatal_Grief_Therapy { get; set; }
        public DbSet<Prenatal_Postpartum_Therapy> Prenatal_Postpartum_Therapy { get; set; }
        public DbSet<Prenatal_TeenMoms_Therapy> Prenatal_TeenMoms_Therapy { get; set; }
        public DbSet<Prenatal_Stress_Therapy> Prenatal_Stress_Therapy { get; set; }

        //Obstetriciab
        public DbSet<Prenatal_Obstetrician_Medication> Prenatal_Obstetrician_Medication { get; set; }
        public DbSet<Prenatal_Obstetrician_Monitoring> Prenatal_Obstetrician_Monitoring { get; set; }
        public DbSet<Prenatal_Obstetrician_Referral> Prenatal_Obstetrician_Referral { get; set; }
        public DbSet<Prenatal_Obstetrician_ViewPatients> Prenatal_Obstetrician_ViewPatients { get; set; }

        //Patient

        public DbSet<Prenatal_History> Prenatal_Histories { get; set; }
        public DbSet<Prenatal_TrackProgress> Prenatal_TrackProgresses { get; set; }

        //Walkin
        public DbSet<AppointmentRequest> appointments { get; set; }
        public DbSet<Updateappoint> ManageAppointments { get; set; }

        //Contact Us
        public DbSet<ContactUs> contactUs { get; set; }

        //Chronic medication
        public DbSet<ChronicMedDoctor> chronicsDoctor { get; set; }
        public DbSet<ChronicMedPatient> chronicsPatient{ get; set; }
        public DbSet<MedicationDosageAdjustment> adjustments { get; set; }
        public DbSet<MedicationFeedback> feedbacks { get; set; }
        public DbSet<MedicationPrescription> medicationPrescriptions { get; set; }
        public DbSet<MedicationRefill> medicationRefill { get; set; }
        public DbSet<MedicationHistory> medicationHistories { get; set; }
        public DbSet<reviews> reviews { get; set; }

        //Vaccinations
        public DbSet<Forum> forum { get; set; }
        public DbSet<ForumReplies> replies { get; set; }
        public DbSet<VaccinationAdminister> vaccinationAdministers { get; set; }
        public DbSet<VaccinationImmunizations> vaccinationImmunizations { get; set; }
        public DbSet<VaccinationReportReactions> reactions { get; set; }
        public DbSet<Vaccinations> vaccinations { get; set; }
        public DbSet<VaccinationTravelMedicine> travelMedicines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CodeMedUser> appUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<PrenatalLogin>().HasNoKey();
        }
    }
}
