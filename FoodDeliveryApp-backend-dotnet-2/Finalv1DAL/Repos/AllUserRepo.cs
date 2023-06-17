using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class AllUserRepo : Repo, IRepo<AllUser, int, bool>
    {
        public bool Create(AllUser type)
        {
            db.AllUsers.Add(type);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var user=db.AllUsers.Find(id);
            db.AllUsers.Remove(user);
            return db.SaveChanges()>0;
        }

        public List<AllUser> Get()
        {
            return db.AllUsers.ToList();
        }

        public AllUser Get(int id)
        {
            return db.AllUsers.Find(id);
        }

        public bool Update(AllUser type)
        {
            var user=Get(type.Id);
            user.Username = type.Username;
            user.Password = type.Password;
            user.UId = type.UId;
            user.Role= type.Role;
            user.Id= type.Id;
            db.AllUsers.AddOrUpdate(user);
            return db.SaveChanges() > 0;

        }
    }
}
