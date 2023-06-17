using Finalv1BLL.ModelDTOs;
using Finalv1DAL;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public class RestaurantService
    {
        public static List<RestaurantDTO> Get()
        {
            var list1 = DataAccessFactory.RestaurantData().Get();
            var list2 = new List<RestaurantDTO>();
            foreach(var item in list1)
            {
                var product = new List<ProductDTO>();
                foreach (var i in item.Products)
                {
                    product.Add(new ProductDTO()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Quantity = i.Quantity,


                    });
                }
                    list2.Add(new RestaurantDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Location = item.Location,
                    Status = item.Status,
                    Rating = item.Rating,
                    Discount = item.Discount,
                    Username = item.Username,
                    Password = item.Password,
                    ProductDTOs= product
                });
            }
            return list2;
        }

        public static RestaurantDTO Get(int id) {
            var allres = Get();
            var res = (from item in allres
                       where item.Id == id
                       select item).SingleOrDefault();
            
            return res;
        }

        public static bool Create(RestaurantDTO restaurantdto) {
            var restaurant = new Restaurant();
            restaurant.Id = restaurantdto.Id;
            restaurant.Name= restaurantdto.Name;
            restaurant.Location= restaurantdto.Location;
            restaurant.Status = restaurantdto.Status;
            restaurant.Rating= restaurantdto.Rating;
            restaurant.Username = restaurantdto.Username;
            restaurant.Password = restaurantdto.Password;
            restaurant.Discount = restaurantdto.Discount;

            DataAccessFactory.RestaurantData().Create(restaurant);

            var getuser = (from i in DataAccessFactory.RestaurantData().Get()
                           where i.Username == restaurantdto.Username &&
                           i.Password == restaurantdto.Password
                           select i).SingleOrDefault();
            var alluser = new AllUser();
            alluser.UId = getuser.Id;
            alluser.Role = "Restaurant";
            alluser.Username = restaurantdto.Username;
            alluser.Password = restaurantdto.Password;
            return DataAccessFactory.AllUserData().Create(alluser);
        }

        public static bool Update(RestaurantDTO restaurantdto)
        {
            var restaurant = new Restaurant();
            restaurant.Id = restaurantdto.Id;
            restaurant.Name = restaurantdto.Name;
            restaurant.Location = restaurantdto.Location;
            restaurant.Status = restaurantdto.Status;
            restaurant.Username = restaurant.Username;
            restaurant.Password = restaurant.Password;
            restaurant.Rating = restaurantdto.Rating;
            restaurant.Discount = restaurantdto.Discount;
            return DataAccessFactory.RestaurantData().Update(restaurant);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.RestaurantData().Delete(id);
        }
    }
}
