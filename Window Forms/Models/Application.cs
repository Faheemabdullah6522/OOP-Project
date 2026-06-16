namespace Window_Forms.Models
{
    public class Application : Entity
    {
        public int ScholarshipId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime AppliedDate { get; set; }
        public string? Comments { get; set; }
        public DateTime? ReviewDate { get; set; }
    }
}
