using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Repository
{
    public class UserManager
    {

        public bool IsValid(string username, string password)
        {
            using (var db = new WebAppContext()) // use your DbConext
            {
                // for the sake of simplicity I use plain text passwords
                // in real world hashing and salting techniques must be implemented
                return db.Users.Any(u => u.UserName == username
                    && u.Password == password);


            }
        }


        public Tuple<bool, User> IsvalidUser(string username, string password)
        {
            Boolean isvalid = false;
            User usr = new User();
            using (var db = new WebAppContext()) // use your DbConext
            {
                usr = db.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

                if (usr != null)
                {
                    isvalid = true;
                }

            }
            return new Tuple<bool, User>(isvalid, usr);

        }
    }
}