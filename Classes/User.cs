using System;

namespace TaskMateApp.Classes
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public int RoleID { get; set; }
        public string RoleName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
