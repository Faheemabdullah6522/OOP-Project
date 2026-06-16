using System;
using System.Collections.Generic;

namespace Window_Forms.Models
{
    /// <summary>
    /// Admin class inheriting from Person
    /// Demonstrates inheritance and polymorphism
    /// </summary>
    public class Admin : Person
    {
        public int UserId { get; set; }
        public string AdminRole { get; set; }  // e.g., "Scholarship Manager", "Reviewer", "Super Admin"
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }
        public int? Department { get; set; }

        /// <summary>
        /// Override GetRole to return 'Admin'
        /// </summary>
        public override string GetRole()
        {
            return $"Admin - {AdminRole}";
        }

        /// <summary>
        /// Check if admin has permission for specific action
        /// </summary>
        public bool HasPermission(string action)
        {
            if (!IsActive)
                return false;

            // Super Admin has all permissions
            if (AdminRole == "Super Admin")
                return true;

            // Define permissions based on role
            var permissions = new Dictionary<string, List<string>>
            {
                { "Scholarship Manager", new List<string> { "CreateScholarship", "EditScholarship", "DeleteScholarship", "ViewApplications" } },
                { "Reviewer", new List<string> { "ReviewApplications", "ApproveApplication", "RejectApplication", "ViewStudents" } },
                { "Support", new List<string> { "ViewStudents", "ViewApplications", "ViewDocuments" } }
            };

            if (permissions.TryGetValue(AdminRole, out var allowedActions))
                return allowedActions.Contains(action);

            return false;
        }

        /// <summary>
        /// Log admin activity
        /// </summary>
        public void LogActivity(string action, string details = "")
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Admin {FullName} ({AdminRole}): {action} - {details}");
        }
    }
}
