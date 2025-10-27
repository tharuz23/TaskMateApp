using System.Data;
using TaskMateApp.DAL;

namespace TaskMateApp.BLL
{
    public static class ActivityBLL
    {
        public static bool Upsert(string username, int taskId, string statusName)
            => ActivityDAL.UpsertUserActivity(username, taskId, statusName);

        public static DataTable GetAll()
            => ActivityDAL.GetAllActivities();

        public static DataTable GetActivitiesFiltered(int? taskId, string statusName)
            => ActivityDAL.GetActivitiesFiltered(taskId, statusName);

        public static DataTable GetByUsername(string username)
            => ActivityDAL.GetActivitiesByUsername(username);

        public static bool Delete(int activityId)
            => ActivityDAL.DeleteActivity(activityId);

        public static bool ResetToDoByTask(int taskId)
            => ActivityDAL.ResetToDoByTask(taskId);

        public static string GetUserActivityStatus(string username, int taskId)
            => ActivityDAL.GetUserActivityStatus(username, taskId);

        public static bool ResetUserToDo(int taskId, string fullName)
            => ActivityDAL.ResetUserToDo(taskId, fullName);
    }
}
