using System;
using System.Collections.Generic;
using System.Linq;
using MMALeavePPortal.DomainModels;

namespace MMALeavePortal.Repositories
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);

        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string email, string password);
        List<User> GetUsersByEmail(string email);
        List<User> GetUsersByUserID(int userid);

        int GetLatestUserID();
    }





    public class UsersRepository:IUsersRepository
    {
        LPDatabase2022DBContext db;
        public UsersRepository()
        {
            db = new LPDatabase2022DBContext();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            
            if (us != null)
            {
                us.Name = u.Name;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();

            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int uid)
        {
            User us = db.Users.Where(temp => temp.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> us = db.Users.OrderBy(temp => temp.Name).ToList();
            return us;
        }


        public List<User> GetUsersByEmailAndPassword(string email, string password)
        {
            List<User> us = db.Users.Where(temp => temp.Email == email && temp.PasswordHash == password).ToList();
            return us;
        }


        public List<User> GetUsersByEmail(string email)
        {
            List<User> us = db.Users.Where(temp => temp.Email == email).ToList();
            return us;
        }

        public List<User> GetUsersByUserID(int userid)
        {
            List<User> us = db.Users.Where(temp => temp.UserID == userid).ToList();
            return us;
        }

        public int GetLatestUserID()
        {
            int us = db.Users.Select(temp=>temp.UserID).Max();
            return us;
        }

    }
}
