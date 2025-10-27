using System.Data.SqlClient;

namespace TaskMateApp.Connection
{
    public static class DBConnection
    {
        private static readonly string connectionString =
            @"Data Source=LAPTOP-JDENBCOP;Initial Catalog=TMS_DB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // ✅ Added method so DAL can call DBConnection.CreateCommand(sql)
        public static SqlCommand CreateCommand(string sql)
        {
            var conn = new SqlConnection(connectionString);
            var cmd = new SqlCommand(sql, conn);
            return cmd;
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
