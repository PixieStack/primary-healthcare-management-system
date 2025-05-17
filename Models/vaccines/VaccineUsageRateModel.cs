using System.Data;

namespace CodeMed.Models.vaccines
{
    public class VaccineUsageRateModel
    {
        public DataTable? DataTable { get; set; }
        public int LowestUsageCount { get; set; }
        public int HighestUsageCount { get; set; }

    }
}
