using System.Data;
using TaskMateApp.Classes;
using TaskMateApp.DAL;

namespace TaskMateApp.BLL
{
    public static class UserBLL
    {
        // ✅ Login
        public static User Login(string username, string password)
            => UserDAL.Login(username, password);

        // ✅ Add New User
        public static bool AddUser(string fullName, string username, string password, int roleId)
            => UserDAL.InsertUser(fullName, username, password, roleId);

        // ✅ Get All Roles
        public static DataTable GetRoles()
            => UserDAL.GetRoles();

        // ✅ Get All Users (for AdminUserTablePage)
        public static DataTable GetAllUsers()
            => UserDAL.GetAllUsers();

        // ✅ Delete a User (for Delete button)
        public static bool DeleteUser(int userId)
            => UserDAL.DeleteUser(userId);
    }
}
