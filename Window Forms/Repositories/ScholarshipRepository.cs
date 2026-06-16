using System.Data;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;

namespace Window_Forms.Repositories
{
    public class ScholarshipRepository
    {
        public List<Scholarship> GetAllActive()
        {
            DataTable table = Database.QueryProc("sp_GetAllActiveScholarships");

            List<Scholarship> list = new List<Scholarship>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Scholarship s = MapRow(table.Rows[i]);
                list.Add(s);
            }

            return list;
        }

        public int Delete(int id)
        {
            SqlParameter param = new SqlParameter("@Id", id);
            return Database.ExecuteProc("sp_DeleteScholarship", param);
        }

        private Scholarship MapRow(DataRow row)
        {
            Scholarship scholarship = new Scholarship();

            scholarship.Id = (int)row["Id"];
            scholarship.Title = row["Title"].ToString();
            scholarship.Description = ReadString(row, "Description");
            scholarship.Eligibility = ReadString(row, "Eligibility");
            scholarship.Amount = (decimal)row["Amount"];
            scholarship.Deadline = ReadDateTime(row, "Deadline");
            scholarship.IsActive = ReadBool(row, "IsActive");
            scholarship.RequiredDocuments = ReadString(row, "RequiredDocuments");
            scholarship.MinimumCGPA = ReadDecimal(row, "MinimumCGPA");
            scholarship.MaxFamilyIncome = ReadDecimal(row, "MaxFamilyIncome");
            scholarship.DegreeProgram = ReadString(row, "DegreeProgram");
            scholarship.SemesterYear = ReadString(row, "SemesterYear");
            scholarship.NeedBased = ReadBool(row, "NeedBased");

            DateTime? createdAt = ReadDateTime(row, "CreatedAt");
            if (createdAt.HasValue)
            {
                scholarship.CreatedAt = createdAt.Value;
            }
            else
            {
                scholarship.CreatedAt = DateTime.Now;
            }

            return scholarship;
        }

        private string ReadString(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false)
            {
                return null;
            }

            if (row[column] == DBNull.Value)
            {
                return null;
            }

            return row[column].ToString();
        }

        private decimal? ReadDecimal(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false)
            {
                return null;
            }

            if (row[column] == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDecimal(row[column]);
        }

        private DateTime? ReadDateTime(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false)
            {
                return null;
            }

            if (row[column] == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDateTime(row[column]);
        }

        private bool ReadBool(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false)
            {
                return false;
            }

            if (row[column] == DBNull.Value)
            {
                return false;
            }

            return Convert.ToBoolean(row[column]);
        }
    }
}
