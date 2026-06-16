using System.Data;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;

namespace Window_Forms.Repositories
{
    public class UserRepository
    {
        public User GetByEmail(string email)
        {
            SqlParameter param = new SqlParameter("@Email", email);

            DataTable table = Database.QueryProc("sp_GetUserByEmail", param);

            if (table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];

            User user = new User();
            user.Id = (int)row["Id"];
            user.Email = row["Email"].ToString();
            user.Password = row["Password"].ToString();
            user.Role = ReadString(row, "Role");
            user.IsVerified = ReadBool(row, "IsVerified");
            user.FullName = ReadString(row, "FullName");
            user.Phone = ReadString(row, "Phone");
            user.Address = ReadString(row, "Address");
            user.DateOfBirth = ReadDateTime(row, "DateOfBirth");
            user.CreatedAt = ReadDateTime(row, "CreatedAt") ?? DateTime.Now;

            if (string.IsNullOrEmpty(user.Role))
            {
                user.Role = "Student";
            }

            return user;
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
