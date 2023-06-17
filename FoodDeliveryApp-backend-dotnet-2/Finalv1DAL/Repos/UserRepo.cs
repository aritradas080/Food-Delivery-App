using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>
    {
        public bool Create(User type)
        {
            db.Users.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exuser = Get(id);
            db.Users.Remove(exuser);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();   
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User type)
        {
            var exuser = Get(type.Id);
            exuser.Name = type.Name;
            exuser.Email = type.Email;
            exuser.Password = type.Password;
            exuser.Username= type.Username;
            exuser.Address = type.Address;
          
            exuser.MobileNumber= type.MobileNumber;
            return db.SaveChanges() > 0;
        }
    }
}
