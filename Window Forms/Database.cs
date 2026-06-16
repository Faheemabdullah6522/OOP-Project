using System.Data;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public static class Database
    {
        public const string ConnectionString = "Server = BRUH\\SQLEXPRESS;Database=project3;Trusted_Connection=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

       

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            DataTable table = new DataTable();
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static object? Scalar(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            object? value = cmd.ExecuteScalar();
            return value == DBNull.Value ? null : value;
        }

       

        public static DataTable QueryProc(string procedure, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            using SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters);

            DataTable table = new DataTable();
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        public static int ExecuteProc(string procedure, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static object? ScalarProc(string procedure, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters);
            object? value = cmd.ExecuteScalar();
            return value == DBNull.Value ? null : value;
        }

       
        public static string? ExecuteProcWithMessage(string procedure, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();

            using SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters);

            var outputParam = new SqlParameter("@StatusMessage", SqlDbType.NVarChar, 255)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            cmd.ExecuteNonQuery();
            return outputParam.Value as string;
        }

        public static object ValueOrDbNull(object? value)
        {
            if (value == null)
                return DBNull.Value;

            if (value is string text && string.IsNullOrWhiteSpace(text))
                return DBNull.Value;

            return value;
        }

    }
}
