using System;
using System.Data;
using System.Data.SqlClient;
using TaskMateApp.Connection;

namespace TaskMateApp.DAL
{
    public static class ActivityDAL
    {
        
        public static DataTable GetAllActivities()
        {
            var dt = new DataTable();
            const string sql = @"
SELECT 
    ua.ActivityID,
    u.FullName AS UserFullName,
    t.TaskID,
    t.Title AS TaskTitle,
    (su.FullName + ' (' + r.RoleName + ')') AS Supervisor,
    s.StatusName AS ActivityStatus,
    t.DueAt,
    ua.SubmittedAt
FROM UserActivities ua
JOIN Users u ON u.UserID = ua.UserID
JOIN Tasks t ON t.TaskID = ua.TaskID
JOIN Users su ON su.UserID = t.SupervisorUserID
JOIN Roles r ON r.RoleID = su.RoleID
JOIN ActivityStatuses s ON s.StatusID = ua.StatusID
ORDER BY ua.SubmittedAt DESC;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        
        public static bool UpsertUserActivity(string username, int taskId, string statusName)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand("sp_UserActivity_Upsert", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.Parameters.AddWithValue("@StatusName", statusName);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        
        public static DataTable GetActivitiesFiltered(int? taskId, string statusName)
        {
            var dt = new DataTable();
            const string sql = @"
SELECT 
    ua.ActivityID,
    u.FullName AS UserFullName,
    t.TaskID,
    t.Title AS TaskTitle,
    s.StatusName AS ActivityStatus,
    ua.SubmittedAt
FROM UserActivities ua
JOIN Users u ON u.UserID = ua.UserID
JOIN Roles ro ON ro.RoleID = u.RoleID
JOIN Tasks t ON t.TaskID = ua.TaskID
JOIN ActivityStatuses s ON s.StatusID = ua.StatusID
WHERE ro.RoleName = 'User'  
  AND (@TaskID IS NULL OR ua.TaskID = @TaskID)
  AND (@StatusName IS NULL OR s.StatusName = @StatusName)
ORDER BY ua.SubmittedAt DESC;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@TaskID", (object?)taskId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StatusName", (object?)statusName ?? DBNull.Value);
                da.Fill(dt);
            }
            return dt;
        }

        
        public static DataTable GetActivitiesByUsername(string username)
        {
            var dt = new DataTable();
            const string sql = @"
SELECT 
    ua.ActivityID,
    t.TaskID,
    t.Title AS TaskTitle,
    s.StatusName AS ActivityStatus,
    t.DueAt,
    ua.SubmittedAt
FROM UserActivities ua
JOIN Users u ON u.UserID = ua.UserID
JOIN Tasks t ON t.TaskID = ua.TaskID
JOIN ActivityStatuses s ON s.StatusID = ua.StatusID
WHERE u.Username = @Username
ORDER BY ua.SubmittedAt DESC;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                da.Fill(dt);
            }
            return dt;
        }

        
        public static bool DeleteActivity(int activityId)
        {
            const string sql = @"DELETE FROM UserActivities WHERE ActivityID = @id";
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", activityId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public static bool ResetToDoByTask(int taskId)
        {
            const string sql = @"
UPDATE ua
SET ua.StatusID = s.StatusID,
    ua.SubmittedAt = NULL
FROM UserActivities ua
JOIN ActivityStatuses s ON s.StatusName = 'To Do'
JOIN Users u ON u.UserID = ua.UserID
JOIN Roles r ON r.RoleID = u.RoleID
WHERE ua.TaskID = @TaskID AND r.RoleName = 'User';"; 

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

       
        public static string GetUserActivityStatus(string username, int taskId)
        {
            const string sql = @"
SELECT s.StatusName
FROM UserActivities ua
JOIN Users u ON u.UserID = ua.UserID
JOIN ActivityStatuses s ON s.StatusID = ua.StatusID
WHERE u.Username = @Username AND ua.TaskID = @TaskID";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? string.Empty;
            }
        }

        
        public static bool ResetUserToDo(int taskId, string fullName)
        {
            const string sql = @"
UPDATE ua
SET ua.StatusID = s.StatusID,
    ua.SubmittedAt = NULL
FROM UserActivities ua
JOIN ActivityStatuses s ON s.StatusName = 'To Do'
JOIN Users u ON u.UserID = ua.UserID
JOIN Roles r ON r.RoleID = u.RoleID
WHERE ua.TaskID = @TaskID 
  AND u.FullName = @FullName
  AND r.RoleName = 'User';";  

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
