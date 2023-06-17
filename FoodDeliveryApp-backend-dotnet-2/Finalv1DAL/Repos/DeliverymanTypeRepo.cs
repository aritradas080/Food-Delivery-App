using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class DeliverymanTypeRepo : Repo, IRepo<DeliverymanType, int, bool>
    {
        public bool Create(DeliverymanType type)
        {
            db.DeliverymanTypes.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exdel = Get(id);
            db.DeliverymanTypes.Remove(exdel);
            return db.SaveChanges() > 0;
        }

        public List<DeliverymanType> Get()
        {
            return db.DeliverymanTypes.ToList();
        }

        public DeliverymanType Get(int id)
        {

            return db.DeliverymanTypes.Find(id);
        }

        public bool Update(DeliverymanType type)
        {
            var exdel = (from item in db.DeliverymanTypes
                         where item.ID == type.ID
                         select item).SingleOrDefault();
            exdel.ID = type.ID;
            exdel.Type = type.Type;
            return db.SaveChanges() > 0;
        }
    }
}
