namespace Window_Forms.Models
{
    public class Notification : Entity
    {
        public string UserEmail { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
