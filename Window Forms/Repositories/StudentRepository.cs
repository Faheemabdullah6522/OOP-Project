using System.Data;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;

namespace Window_Forms.Repositories
{
    public class StudentRepository
    {
        public Student GetByEmail(string email)
        {
            SqlParameter param = new SqlParameter("@Email", email);

            DataTable table = Database.QueryProc("sp_GetStudentProfile", param);

            if (table.Rows.Count == 0)
            {
                return null;
            }

            return MapRow(table.Rows[0]);
        }

        private Student MapRow(DataRow row)
        {
            Student student = new Student();

            student.Id = (int)row["Id"];
            student.UserEmail = ReadString(row, "UserEmail");
            student.Email = ReadString(row, "Email");
            student.FullName = ReadString(row, "FullName");
            student.FatherName = ReadString(row, "FatherName");
            student.CNIC = ReadString(row, "CNIC");
            student.MobileNumber = ReadString(row, "MobileNumber");
            student.Gender = ReadString(row, "Gender");
            student.Religion = ReadString(row, "Religion");
            student.DateOfAdmission = ReadDateTime(row, "DateOfAdmission");
            student.DisabilityStatus = ReadString(row, "DisabilityStatus");
            student.FamilyIncome = ReadDecimal(row, "FamilyIncome");
            student.SemesterYear = ReadString(row, "SemesterYear");
            student.RollNumber = ReadString(row, "RollNumber");
            student.Department = ReadString(row, "Department");
            student.DegreeProgram = ReadString(row, "DegreeProgram");
            student.UniversityName = ReadString(row, "UniversityName");
            student.RegistrationNumber = ReadString(row, "RegistrationNumber");
            student.CGPA = ReadDecimal(row, "CGPA");
            student.DateOfBirth = ReadDateTime(row, "DateOfBirth");
            student.DomicileDistrict = ReadString(row, "DomicileDistrict");
            student.Province = ReadString(row, "Province");
            student.District = ReadString(row, "District");
            student.TownVillage = ReadString(row, "TownVillage");
            student.MailingAddress = ReadString(row, "MailingAddress");
            student.PermanentAddress = ReadString(row, "PermanentAddress");
            student.SSCBoard = ReadString(row, "SSCBoard");
            student.SSCRollNo = ReadString(row, "SSCRollNo");
            student.SSCYear = ReadInt(row, "SSCYear");
            student.SSCMarks = ReadDecimal(row, "SSCMarks");
            student.SSCPercentage = ReadDecimal(row, "SSCPercentage");
            student.SSCInstitute = ReadString(row, "SSCInstitute");
            student.HSSCBoard = ReadString(row, "HSSCBoard");
            student.HSSCRollNo = ReadString(row, "HSSCRollNo");
            student.HSSCYear = ReadInt(row, "HSSCYear");
            student.HSSCMarks = ReadDecimal(row, "HSSCMarks");
            student.HSSCPercentage = ReadDecimal(row, "HSSCPercentage");
            student.HSSCInstitute = ReadString(row, "HSSCInstitute");
            student.UpdatedAt = ReadDateTime(row, "UpdatedAt");

            DateTime? createdAt = ReadDateTime(row, "CreatedAt");
            if (createdAt.HasValue)
            {
                student.CreatedAt = createdAt.Value;
            }
            else
            {
                student.CreatedAt = DateTime.Now;
            }

            return student;
        }

        public byte[]? GetFingerprintByEmail(string email)
        {
            SqlParameter param = new SqlParameter("@Email", email);
            DataTable table = Database.QueryProc("sp_GetFingerprintTemplate", param);

            if (table.Rows.Count == 0 || table.Rows[0]["FingerprintTemplate"] == DBNull.Value)
                return null;

            return (byte[])table.Rows[0]["FingerprintTemplate"];
        }

        public void UpdateFingerprintByEmail(string email, byte[]? template)
        {
            SqlParameter paramEmail = new SqlParameter("@Email", email);
            SqlParameter paramTemplate = new SqlParameter("@Template", SqlDbType.VarBinary, -1)
            {
                Value = template ?? (object)DBNull.Value
            };
            Database.ExecuteProc("sp_UpdateFingerprintTemplate", paramEmail, paramTemplate);
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

        private int? ReadInt(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false)
            {
                return null;
            }

            if (row[column] == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(row[column]);
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
    }
}
