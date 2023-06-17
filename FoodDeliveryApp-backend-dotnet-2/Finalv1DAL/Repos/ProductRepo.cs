using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product type)
        {
           db.Products.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
           var expro = Get(id);
            db.Products.Remove(expro);  
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public bool Update(Product type)
        {
            var prodcut = db.Products.Find(type.Id);
            prodcut.Id=type.Id;
            prodcut.Name=type.Name;
            prodcut.Restaurant=type.Restaurant;
            prodcut.Price=type.Price;
            prodcut.Quantity=type.Quantity;
            prodcut.Rid=type.Rid;
            prodcut.Cid=type.Cid;

            return db.SaveChanges()>0;
        }
    }
}
