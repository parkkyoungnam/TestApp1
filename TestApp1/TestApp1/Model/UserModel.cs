using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp1.Model
{
    public class UserModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime? RegistDate { get; set; }
    }

    public static class Constants
    {
        public static string Username = string.Empty;
        public static string Password = string.Empty;
    }
}
