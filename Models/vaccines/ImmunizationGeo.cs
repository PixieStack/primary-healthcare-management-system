using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CodeMed.Models.vaccines
{
    public class ImmunizationGeo
    {
        public DataTable? DataTable { get; set; }
        [Display(Name = "Age Group 1")]
        public int AgeGroup1 { get; set; }

        [Display(Name = "Age Group 2")]
        public int AgeGroup2 { get; set; }
    }
}
