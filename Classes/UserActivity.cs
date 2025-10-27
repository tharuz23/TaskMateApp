using System;

namespace TaskMateApp.Classes
{
    public class UserActivity
    {
        public int ActivityID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; } = "";
        public int TaskID { get; set; }
        public string Title { get; set; } = "";
        public int StatusID { get; set; }
        public string StatusName { get; set; } = "";
        public DateTime SubmittedAt { get; set; }
        public DateTime? DueAt { get; set; }
        public string Description { get; set; } = "";
    }
}
