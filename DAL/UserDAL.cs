using System;
using System.Data;
using System.Data.SqlClient;
using TaskMateApp.Classes;
using TaskMateApp.Connection;

namespace TaskMateApp.DAL
{
    public static class UserDAL
    {
        
        public static User Login(string username, string passwordPlain)
        {
            const string sql = @"
SELECT u.UserID, u.FullName, u.Username, u.PasswordHash, 
       u.RoleID, r.RoleName, u.CreatedAt
FROM Users u
JOIN Roles r ON r.RoleID = u.RoleID
WHERE u.Username = @Username AND u.PasswordHash = @Password";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", passwordPlain);

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        return null;

                    return new User
                    {
                        UserID = Convert.ToInt32(rd["UserID"]),
                        FullName = rd["FullName"].ToString(),
                        Username = rd["Username"].ToString(),
                        PasswordHash = rd["PasswordHash"].ToString(),
                        RoleID = Convert.ToInt32(rd["RoleID"]),
                        RoleName = rd["RoleName"].ToString(),
                        CreatedAt = Convert.ToDateTime(rd["CreatedAt"])
                    };
                }
            }
        }

        
        public static DataTable GetRoles()
        {
            const string sql = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";

            using (var conn = DBConnection.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        public static bool InsertUser(string fullName, string username, string passwordPlain, int roleId)
        {
            const string sql = @"
INSERT INTO Users (FullName, Username, PasswordHash, RoleID)
VALUES (@FullName, @Username, @Password, @RoleID)";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", passwordPlain);
                cmd.Parameters.AddWithValue("@RoleID", roleId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public static DataTable GetAllUsers()
        {
            const string sql = @"
SELECT u.UserID, u.FullName, u.Username, r.RoleName
FROM Users u
JOIN Roles r ON r.RoleID = u.RoleID
ORDER BY u.UserID";

            using (var conn = DBConnection.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        public static bool DeleteUser(int userId)
        {
            const string sql = "DELETE FROM Users WHERE UserID = @UserID";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
