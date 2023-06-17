using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class OrderDetailsRepo : Repo, IRepo<OrderDetails, int, bool>
    {
        public bool Create(OrderDetails type)
        {
            db.OrderDetails.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exord = Get(id);
            db.OrderDetails.Remove(exord);
            return db.SaveChanges() > 0;
        }

        public List<OrderDetails> Get()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetails Get(int id)
        {
            return db.OrderDetails.Find(id);

        }

        public bool Update(OrderDetails type)
        {
            var exord = (from item in db.OrderDetails
                         where item.Id == type.Id
                         select item).SingleOrDefault();
            exord.Id = type.Id;
            exord.Pid = type.Pid;
            exord.Oid  = type.Oid;
            exord.Price= type.Price;
            exord.Quantity = type.Quantity;
            return db.SaveChanges() > 0;
        }
    }
}
