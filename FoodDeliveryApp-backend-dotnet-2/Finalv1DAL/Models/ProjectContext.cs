using Finalv1DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Restaurant> Restaurants { get; set;}

        public DbSet<Product> Products { get; set;}

        public DbSet<Order> Orders { get; set;}

        public DbSet<OrderDetails> OrderDetails { get; set;}

        public DbSet<Deliveryman> Deliverymans { get; set;}

        public DbSet<MonthlyIncome> MonthlyIncomes { get;set;}

        public DbSet<DeliveryLog> DeliveryLogs { get;set;}
        public DbSet<Admin> Admins { get; set;}

        public DbSet<DeliverymanType> DeliverymanTypes { get; set;}
        public DbSet<Chat> Chats { get; set;}
        public DbSet<FeedBack> FeedBacks { get; set;}
        public DbSet<AllUser> AllUsers { get; set;}
        public DbSet<Token> Tokens { get; set;}
    }
}
