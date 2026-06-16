using System;
using System.Collections.Generic;

namespace Window_Forms.Models
{
    /// <summary>
    /// Scholarship Application model
    /// </summary>
    public class ScholarshipApplication
    {
        public int Id { get; set; }
        public int ScholarshipId { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }  // Pending, Approved, Rejected, Under Review
        public DateTime AppliedDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string Comments { get; set; }
        public string ReviewerEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Scholarship Scholarship { get; set; }
        public Student Student { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();

        /// <summary>
        /// Check if application can be modified
        /// </summary>
        public bool CanModify()
        {
            return Status == "Pending";
        }

        /// <summary>
        /// Get days since application
        /// </summary>
        public int GetDaysSinceApplication()
        {
            return (int)(DateTime.Now - AppliedDate).TotalDays;
        }
    }
}
