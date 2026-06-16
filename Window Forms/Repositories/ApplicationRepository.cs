using System.Data;
using Microsoft.Data.SqlClient;

namespace Window_Forms.Repositories
{
    public class ApplicationRepository
    {
        // Now only returns true if there is an ACTIVE (Pending/Approved) application.
        // A Rejected or Withdrawn application does NOT count — student can reapply.
        public bool HasApplied(int scholarshipId, string email)
        {
            object result = Database.ScalarProc("sp_CheckExistingApplication",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", email),
                new SqlParameter("@StatusFilter", "Active"));

            return Convert.ToInt32(result) > 0;
        }

        // No changes needed — returns ALL rows including old Rejected/Withdrawn
        // and new Pending side by side, newest first.
        public DataTable GetMyApplications(string email)
        {
            return Database.QueryProc("sp_GetStudentApplications", new SqlParameter("@UserEmail", email));
        }
       // used by Save for Later to check if a draft already exists
public bool HasDraft(int scholarshipId, string email)
        {
            object result = Database.ScalarProc("sp_CheckDraftApplication",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", email));

            return Convert.ToInt32(result) > 0;
        }
    }
}