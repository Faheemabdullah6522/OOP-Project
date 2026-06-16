

namespace Window_Forms
{
    public static class Session
    {
        public static int? UserId { get; set; }
        public static string? UserEmail { get; set; }
        public static string? UserRole { get; set; }
        public static string? FullName { get; set; }
        public static string? Phone { get; set; }
        public static string? Address { get; set; }
        public static DateTime? DateOfBirth { get; set; }
        public static string? Department { get; set; }
        public static string? DegreeProgram { get; set; }
        public static string? SemesterYear { get; set; }
        public static decimal? FamilyIncome { get; set; }
        public static decimal? CGPA { get; set; }

        public static void Logout()
        {
            UserId = null;
            UserEmail = null;
            UserRole = null;
            FullName = null;
            Phone = null;
            Address = null;
            DateOfBirth = null;
            Department = null;
            DegreeProgram = null;
            SemesterYear = null;
            FamilyIncome = null;
            CGPA = null;
        }
    }
}
