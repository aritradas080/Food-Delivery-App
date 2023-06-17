using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class RestaurantRepo : Repo, IRepo<Restaurant, int, bool>
    {
        public bool Create(Restaurant type)
        {
            db.Restaurants.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exres = Get(id);
            db.Restaurants.Remove(exres);
            return db.SaveChanges() > 0;
        }

        public List<Restaurant> Get()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.Find(id);
        }

        public bool Update(Restaurant type)
        {
              var exuser = Get(type.Id);
           
            exuser.Name = type.Name;
            exuser.Location = type.Location;
            exuser.Status = type.Status;
            exuser.Rating = type.Rating;
            exuser.Discount = type.Discount;
            return db.SaveChanges() > 0;
        }
    }
}
