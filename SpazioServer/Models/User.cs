using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpazioServer.Models
{
    public class User
    {
        int id;
        string userName;
        string email;
        string password;
        string phoneNumber;
        string photo;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Photo { get => photo; set => photo = value; }

        public User() { }

        public User(int id, string userName, string email, string password, string phoneNumber, string photo)
        {
            this.id = id;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.photo = photo;
        }

        public List<User> getUsers()
        {
            DBServices dbs = new DBServices();
            return dbs.readUsers();
        }
        public int insert()
        {
            DBServices dbs = new DBServices();
            int numAffected = dbs.insert(this);
            return numAffected;
        }
        
    }
}