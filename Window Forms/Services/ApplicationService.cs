using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;
using Window_Forms.Repositories;

namespace Window_Forms.Services
{
    /// <summary>
    /// Service to manage scholarship applications
    /// Demonstrates business logic separation
    /// </summary>
    public class ApplicationService
    {
        private readonly StudentRepository _studentRepository = new StudentRepository();

        /// <summary>
        /// Submit new application
        /// </summary>
        public bool SubmitApplication(int scholarshipId, string studentEmail, string comments)
        {
            try
            {
                // Check if already applied
                object count = Database.ScalarProc("sp_CheckExistingApplication",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", studentEmail));

                if (Convert.ToInt32(count) > 0)
                    throw new Exception("You have already applied for this scholarship");

                // Insert application
                Database.ExecuteProc("sp_SubmitApplicationWithComments",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", studentEmail),
                    new SqlParameter("@StudentComments", comments ?? (object)DBNull.Value));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error submitting application: {ex.Message}");
            }
        }

        /// <summary>
        /// Get student applications
        /// </summary>
        public List<ScholarshipApplication> GetStudentApplications(string studentEmail)
        {
            try
            {
                var applications = new List<ScholarshipApplication>();
                var dt = Database.QueryProc("sp_GetStudentApplications",
                    new SqlParameter("@UserEmail", studentEmail));

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    applications.Add(new ScholarshipApplication
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        ScholarshipId = Convert.ToInt32(row["ScholarshipId"]),
                        UserEmail = row["UserEmail"].ToString(),
                        Status = row["Status"].ToString(),
                        AppliedDate = Convert.ToDateTime(row["AppliedDate"]),
                        ReviewDate = row["ReviewDate"] != DBNull.Value ? Convert.ToDateTime(row["ReviewDate"]) : (DateTime?)null,
                        Comments = row["Comments"]?.ToString()
                    });
                }

                return applications;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving applications: {ex.Message}");
            }
        }

        /// <summary>
        /// Approve application
        /// </summary>
        public bool ApproveApplication(int applicationId, string reviewerEmail, string comments = "")
        {
            try
            {
                Database.ExecuteProc("sp_UpdateApplicationStatus",
                    new SqlParameter("@ApplicationId", applicationId),
                    new SqlParameter("@Status", "Approved"),
                    new SqlParameter("@Comments", comments ?? (object)DBNull.Value));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error approving application: {ex.Message}");
            }
        }

        /// <summary>
        /// Reject application
        /// </summary>
        public bool RejectApplication(int applicationId, string reviewerEmail, string reason)
        {
            try
            {
                Database.ExecuteProc("sp_UpdateApplicationStatus",
                    new SqlParameter("@ApplicationId", applicationId),
                    new SqlParameter("@Status", "Rejected"),
                    new SqlParameter("@Comments", reason ?? (object)DBNull.Value));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error rejecting application: {ex.Message}");
            }
        }
    }
}
