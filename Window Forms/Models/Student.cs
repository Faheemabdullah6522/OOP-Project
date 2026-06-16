namespace Window_Forms.Models
{
    public class Student : User
    {
        public string? UserEmail { get; set; }
        public string? FatherName { get; set; }
        public string? CNIC { get; set; }
        public string? MobileNumber { get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public string? DisabilityStatus { get; set; }
        public decimal? FamilyIncome { get; set; }
        public string? SemesterYear { get; set; }
        public string? RollNumber { get; set; }
        public string? Department { get; set; }
        public string? DegreeProgram { get; set; }
        public string? UniversityName { get; set; }
        public string? RegistrationNumber { get; set; }
        public decimal? CGPA { get; set; }
        public string? DomicileDistrict { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? TownVillage { get; set; }
        public string? MailingAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? SSCBoard { get; set; }
        public string? SSCRollNo { get; set; }
        public int? SSCYear { get; set; }
        public decimal? SSCMarks { get; set; }
        public decimal? SSCPercentage { get; set; }
        public string? SSCInstitute { get; set; }
        public string? HSSCBoard { get; set; }
        public string? HSSCRollNo { get; set; }
        public int? HSSCYear { get; set; }
        public decimal? HSSCMarks { get; set; }
        public decimal? HSSCPercentage { get; set; }
        public string? HSSCInstitute { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[]? FingerprintTemplate { get; set; }
    }
}
