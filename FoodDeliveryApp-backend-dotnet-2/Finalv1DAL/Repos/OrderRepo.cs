using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, int, bool>
    {
        public bool Create(Order type)
        {
            db.Orders.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exor = Get(id);
            db.Orders.Remove(exor);
            return db.SaveChanges() > 0;
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public bool Update(Order type)
        {
           var exor = (from item in db.Orders
                       where item.Id== type.Id
                       select item).SingleOrDefault();
            exor.Id= type.Id;
            exor.Rid  = type.Rid;   
            exor.Uid = type.Uid; 
            exor.RestaurantName = type.RestaurantName;
            exor.lat = type.lat;
            exor.lan= type.lan;
            exor.Date= type.Date;   
            exor.OrderStatus= type.OrderStatus;
            exor.Amount= type.Amount;
            //exor.Did = type.Did;
            return db.SaveChanges() > 0;
        }
    }
}
