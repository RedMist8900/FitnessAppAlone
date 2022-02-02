using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int iD, string name, string password, string email)
        {
            ID = iD;
            Name = name;
            Password = password;
            Email = email;
        }

        public User()
        {
        }
    }
}
