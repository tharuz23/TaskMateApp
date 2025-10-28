using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TaskMateApp.Classes;
using TaskMateApp.Connection;

namespace TaskMateApp.DAL
{
    public class TaskDAL
    {
        public static List<TaskItem> GetAllTasksFromView()
        {
            var list = new List<TaskItem>();
            const string sql = @"SELECT TaskNo, Title, Description, Supervisor, DueAt, IsLocked, CreatedBy 
                                 FROM v_AdminTasks 
                                 ORDER BY TaskNo";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Connection.Open();
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var item = new TaskItem
                {
                    TaskID = rd.GetInt32(0),
                    Title = rd.GetString(1),
                    Description = rd.IsDBNull(2) ? "" : rd.GetString(2),
                    Supervisor = rd.GetString(3),
                    DueAt = rd.IsDBNull(4) ? (DateTime?)null : rd.GetDateTime(4),
                    IsLocked = !rd.IsDBNull(5) && rd.GetBoolean(5),
                    CreatedBy = rd.IsDBNull(6) ? "" : rd.GetString(6)
                };
                list.Add(item);
            }
            rd.Close();
            cmd.Connection.Close();
            return list;
        }

        // ✅ FIXED FUNCTION — shows tasks created by OR supervised by the logged-in admin
        public static List<TaskItem> GetTasksByCreator(string username)
        {
            var list = new List<TaskItem>();

            const string sql = @"
SELECT t.TaskID, t.Title, t.Description,
       (u.FullName + ' (' + r.RoleName + ')') AS Supervisor,
       t.DueAt, t.IsLocked, t.CreatedBy
FROM Tasks t
JOIN Users u ON u.UserID = t.SupervisorUserID
JOIN Roles r ON r.RoleID = u.RoleID
WHERE t.CreatedBy = @u
   OR u.Username = @u
ORDER BY t.TaskID DESC";

            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Connection.Open();

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var item = new TaskItem
                {
                    TaskID = rd.GetInt32(0),
                    Title = rd.GetString(1),
                    Description = rd.IsDBNull(2) ? "" : rd.GetString(2),
                    Supervisor = rd.GetString(3),
                    DueAt = rd.IsDBNull(4) ? (DateTime?)null : rd.GetDateTime(4),
                    IsLocked = !rd.IsDBNull(5) && rd.GetBoolean(5),
                    CreatedBy = rd.IsDBNull(6) ? "" : rd.GetString(6)
                };
                list.Add(item);
            }

            rd.Close();
            cmd.Connection.Close();
            return list;
        }

        public static TaskItem GetTaskById(int taskId)
        {
            const string sql = @"
SELECT t.TaskID, t.Title, t.Description, t.SupervisorUserID, 
       (u.FullName + ' (' + r.RoleName + ')') AS Supervisor, 
       t.DueAt, t.CreatedAt, t.IsLocked, t.CreatedBy
FROM Tasks t
JOIN Users u ON u.UserID = t.SupervisorUserID
JOIN Roles r ON r.RoleID = u.RoleID
WHERE t.TaskID = @id";

            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.Connection.Open();
            var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                rd.Close();
                cmd.Connection.Close();
                return null;
            }

            var task = new TaskItem
            {
                TaskID = rd.GetInt32(0),
                Title = rd.GetString(1),
                Description = rd.IsDBNull(2) ? "" : rd.GetString(2),
                SupervisorUserID = rd.GetInt32(3),
                Supervisor = rd.GetString(4),
                DueAt = rd.IsDBNull(5) ? (DateTime?)null : rd.GetDateTime(5),
                CreatedAt = rd.GetDateTime(6),
                IsLocked = !rd.IsDBNull(7) && rd.GetBoolean(7),
                CreatedBy = rd.IsDBNull(8) ? "" : rd.GetString(8)
            };
            rd.Close();
            cmd.Connection.Close();
            return task;
        }

        public static int AddTask(string title, string description, int supervisorUserId, DateTime? dueAt, string createdBy)
        {
            const string sql = @"
INSERT INTO Tasks(Title, Description, SupervisorUserID, DueAt, CreatedBy, IsLocked)
OUTPUT INSERTED.TaskID
VALUES(@t, @d, @s, @due, @cb, 0)";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
            cmd.Parameters.AddWithValue("@s", supervisorUserId);
            cmd.Parameters.AddWithValue("@due", dueAt.HasValue ? (object)dueAt.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@cb", createdBy);
            cmd.Connection.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public static int AddTaskWithLock(string title, string description, int supervisorUserId, DateTime? dueAt, string createdBy, bool isLocked)
        {
            const string sql = @"
INSERT INTO Tasks(Title, Description, SupervisorUserID, DueAt, CreatedBy, IsLocked)
OUTPUT INSERTED.TaskID
VALUES(@t, @d, @s, @due, @cb, @lock)";

            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
            cmd.Parameters.AddWithValue("@s", supervisorUserId);
            cmd.Parameters.AddWithValue("@due", dueAt.HasValue ? (object)dueAt.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@cb", createdBy);
            cmd.Parameters.AddWithValue("@lock", isLocked);
            cmd.Connection.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public static bool LockTask(int taskId, bool lockStatus)
        {
            const string sql = @"UPDATE Tasks SET IsLocked=@lock WHERE TaskID=@id";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@lock", lockStatus);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.Connection.Open();
            bool ok = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return ok;
        }

        public static bool UpdateTask(int taskId, string title, string description, int supervisorUserId, DateTime? dueAt)
        {
            const string sql = @"
UPDATE Tasks
SET Title=@t, Description=@d, SupervisorUserID=@s, DueAt=@due
WHERE TaskID=@id";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
            cmd.Parameters.AddWithValue("@s", supervisorUserId);
            cmd.Parameters.AddWithValue("@due", dueAt.HasValue ? (object)dueAt.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.Connection.Open();
            bool ok = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return ok;
        }

        public static bool DeleteTask(int taskId)
        {
            const string sql = @"DELETE FROM Tasks WHERE TaskID=@id";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.Connection.Open();
            bool ok = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return ok;
        }

        public static int GetNextTaskId()
        {
            const string sql = "SELECT ISNULL(MAX(TaskID), 0) + 1 FROM Tasks";
            var cmd = DBConnection.CreateCommand(sql);
            cmd.Connection.Open();
            int nextId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return nextId;
        }
    }
}
