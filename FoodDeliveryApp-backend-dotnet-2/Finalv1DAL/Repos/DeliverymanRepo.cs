using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class DeliverymanRepo : Repo, IRepo<Deliveryman, int, bool>
    {
        public bool Create(Deliveryman type)
        {
            db.Deliverymans.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exdel = Get(id);
            db.Deliverymans.Remove(exdel);
            return db.SaveChanges() > 0;
        }

        public List<Deliveryman> Get()
        {
            return db.Deliverymans.ToList();
        }

        public Deliveryman Get(int id)
        {
            return db.Deliverymans.Find(id);
        }

        public bool Update(Deliveryman type)
        {
            var exdel = (from item in db.Deliverymans
                         where item.ID == type.ID
                         select item).SingleOrDefault();
            exdel.ID= type.ID;
            exdel.Name= type.Name;
            exdel.Rating = type.Rating;
            exdel.Location= type.Location;
            exdel.DeliveryManStatus = type.DeliveryManStatus;
            exdel.MobileNumber= type.MobileNumber;
            exdel.Username= type.Username;
            exdel.Password= type.Password;
            exdel.dtId= type.dtId;
            return db.SaveChanges() > 0;
            
        }
    }
}
