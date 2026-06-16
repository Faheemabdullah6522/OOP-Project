namespace Window_Forms.Models
{
    public class Document : Entity
    {
        public string UserEmail { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
    }
}
