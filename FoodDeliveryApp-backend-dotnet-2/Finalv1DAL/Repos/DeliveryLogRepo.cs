using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class DeliveryLogRepo : Repo, IRepo<DeliveryLog, int, bool>
    {
        public bool Create(DeliveryLog type)
        {
            db.DeliveryLogs.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exdellog = Get(id);
            db.DeliveryLogs.Remove(exdellog);
            return db.SaveChanges() > 0;
        }

        public List<DeliveryLog> Get()
        {
            return db.DeliveryLogs.ToList();
        }

        public DeliveryLog Get(int id)
        {
            return db.DeliveryLogs.Find(id);
        }

        public bool Update(DeliveryLog type)
        {
            var dlog = (from item in db.DeliveryLogs
                        where item.Id == type.Id
                        select item).SingleOrDefault();
            dlog.Id = type.Id;
            dlog.DeliveryId = type.DeliveryId;
            dlog.Time = type.Time;
            dlog.Income= type.Income;
            dlog.flag = type.flag;
            dlog.OrderId= type.OrderId;

            return db.SaveChanges() > 0;
            
        }
    }
}
