using System;

namespace TaskMateApp.Classes
{
    public class TaskItem
    {
        public int TaskID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int SupervisorUserID { get; set; }
        public string Supervisor { get; set; } = ""; 
        public DateTime? DueAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }

    }
}
