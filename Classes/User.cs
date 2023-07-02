using System;
using System.Xml.Serialization;

namespace CoorseProdject01.Classes
{
    [Serializable]
    public class User
    {
        public User()
        {
        }
        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public bool CheckPassword(string password)
        {
            return (password == Password);
        }
    }

}
