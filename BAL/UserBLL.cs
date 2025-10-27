using System.Data;
using TaskMateApp.Classes;
using TaskMateApp.DAL;

namespace TaskMateApp.BLL
{
    public static class UserBLL
    {
   
        public static User Login(string username, string password)
            => UserDAL.Login(username, password);

    
        public static bool AddUser(string fullName, string username, string password, int roleId)
            => UserDAL.InsertUser(fullName, username, password, roleId);

       
        public static DataTable GetRoles()
            => UserDAL.GetRoles();

        
        public static DataTable GetAllUsers()
            => UserDAL.GetAllUsers();

        
        public static bool DeleteUser(int userId)
            => UserDAL.DeleteUser(userId);
    }
}
