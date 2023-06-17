using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using Finalv1DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL
{
    public class DataAccessFactory 
    {
        public static IRepo<User,int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Cuisine, int, bool> CuisineData()
        {
            return new CuisineRepo();
        }

        public static IRepo<Restaurant, int, bool> RestaurantData() { 
            
            return new RestaurantRepo();
        }

        public static IRepo<Order, int, bool> OrderData() {
            return new OrderRepo(); 
        }

        public static IRepo<Product, int, bool> ProductData() { 
            return new ProductRepo(); 
        }

        public static IRepo<OrderDetails, int, bool> OrderDetailsData() {
            return new OrderDetailsRepo();
        }

        public static IRepo<Deliveryman, int, bool> DeliverymanData()
        {
            return new DeliverymanRepo();   
        }

        public static IRepo<MonthlyIncome, int, bool> MonthlyIncomeData()
        {
            return new MonthlyIncomeRepo();
        }

        public static IRepo<DeliveryLog, int, bool> DeliveryLogData() {
            return new DeliveryLogRepo();
        }

        public static IRepo<DeliverymanType,int,bool> DeliverymanTypeData()
        {
            return new DeliverymanTypeRepo();
        }
        public static IRepo<Chat, int, bool> ChatData()
        {
            return new ChatRepo();
        }

        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
            
        }
        public static IRepo<FeedBack, int, bool> FeedbackData()
        {
            return new FeedBackRepo();
        }
        public static IRepo<AllUser, int, bool> AllUserData()
        {
            return new AllUserRepo();
        }
        public static IRepo<Token, int, string> TokenData() {
             return new TokenRepo();
        }


    }
}
