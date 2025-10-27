using System;
using System.Collections.Generic;
using TaskMateApp.Classes;
using TaskMateApp.DAL;

namespace TaskMateApp.BLL
{
    public static class TaskBLL
    {
        public static List<TaskItem> GetAllTasks()
            => TaskDAL.GetAllTasksFromView();

        public static List<TaskItem> GetTasksByAdmin(string username)
            => TaskDAL.GetTasksByCreator(username);

        public static TaskItem GetTaskById(int taskId)
            => TaskDAL.GetTaskById(taskId);

        public static int AddTask(string title, string description, int supervisorUserId, DateTime? dueAt, string createdBy)
            => TaskDAL.AddTask(title, description, supervisorUserId, dueAt, createdBy);

        public static int AddTaskWithLock(string title, string description, int supervisorUserId, DateTime? dueAt, string createdBy, bool isLocked)
            => TaskDAL.AddTaskWithLock(title, description, supervisorUserId, dueAt, createdBy, isLocked);

        public static bool UpdateTask(int taskId, string title, string description, int supervisorUserId, DateTime? dueAt)
            => TaskDAL.UpdateTask(taskId, title, description, supervisorUserId, dueAt);

        public static bool DeleteTask(int taskId)
            => TaskDAL.DeleteTask(taskId);

        public static int GetNextTaskId()
            => TaskDAL.GetNextTaskId();

        public static bool LockTask(int taskId, bool isLocked)
            => TaskDAL.LockTask(taskId, isLocked);
    }
}
