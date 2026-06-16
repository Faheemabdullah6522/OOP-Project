namespace Window_Forms.Models
{
    public class Scholarship : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Eligibility { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsActive { get; set; } = true;
        public string? RequiredDocuments { get; set; }
        public decimal? MinimumCGPA { get; set; }
        public decimal? MaxFamilyIncome { get; set; }
        public string? DegreeProgram { get; set; }
        public string? SemesterYear { get; set; }
        public bool NeedBased { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
