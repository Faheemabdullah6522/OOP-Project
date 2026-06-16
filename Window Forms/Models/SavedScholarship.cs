namespace Window_Forms.Models
{
    public class SavedScholarship : Entity
    {
        public string UserEmail { get; set; } = string.Empty;
        public int ScholarshipId { get; set; }
        public DateTime SavedDate { get; set; }
    }
}
