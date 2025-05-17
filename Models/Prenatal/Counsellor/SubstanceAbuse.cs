namespace CodeMed.Models.Prenatal.Counsellor
{
    public class SubstanceAbuse
    {
        int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public DateTime? Date { get; set; }
        public string? Substance_Understanding { get; set; }
        public string? Motivation { get; set; }
        public string? Goals { get; set; }
        public string? Coping_Skills { get; set; }
        public string? Relapse_Prevention { get; set; }
        public string? CoCurrent_Disorders { get; set; }
        public string? Social_Support { get; set; }
        public string? Lifestyle_Changes { get; set; }
        public string? Legal_Employment { get; set; }
        public string? LongTerm_Recovery { get; set; }
        public string? Session_Notes { get; set; }
    }
}
