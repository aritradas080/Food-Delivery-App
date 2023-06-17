using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class FeedBackRepo : Repo, IRepo<FeedBack, int, bool>
    {
        public bool Create(FeedBack type)
        {
            db.FeedBacks.Add(type);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var feedback=Get(id);
            db.FeedBacks.Remove(feedback);
            return db.SaveChanges() > 0;
        }

        public List<FeedBack> Get()
        {
            return db.FeedBacks.ToList();
        }

        public FeedBack Get(int id)
        {
            return db.FeedBacks.Find(id);
        }

        public bool Update(FeedBack type)
        {
            var feedbak = Get(type.Id);
            feedbak.Name = type.Name;
            feedbak.Email   = type.Email;
            feedbak.Body= type.Body;
            return db.SaveChanges() > 0;


        }
    }
}
