using Finalv1BLL.ModelDTOs;
using Finalv1DAL;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var list1 = DataAccessFactory.OrderData().Get();
            var list2 = new List<OrderDTO>();
            foreach (var item in list1)
            {
                var orderList = new List<OrderDetailsDTO >();
                foreach(var item2 in item.OrderDetails)
                {
                    orderList.Add(new OrderDetailsDTO()
                    {
                        Id = item2.Id,
                        Oid = item2.Oid,
                        Pid = item2.Pid,
                        Price = item2.Price,
                        Quantity = item2.Quantity,

                    });
                }
                list2.Add(new OrderDTO()
                {
                    Id = item.Id,
                    Rid = item.Rid,
                    Uid = item.Uid,
                    RestaurantName = item.RestaurantName,
                    lat=item.lat,
                    lan=item.lan,
                    Date = item.Date,
                    OrderStatus = item.OrderStatus,
                    Amount = item.Amount,
                    OrderDetailsDTOs= orderList

                }); ;
            }
            return list2;
        }

        public static OrderDTO Get(int id)
        {
            var allord = Get();
            if (allord != null)
            {
                var ord = (from item in allord
                           where item.Id == id
                           select item).SingleOrDefault();
                return ord;
            }
        return null;
        }

        public static bool Create(OrderDTO orderdto)
        {
            var orderss = DataAccessFactory.OrderData().Get();
            
            var pro = DataAccessFactory.ProductData().Get();
            var amount = 0;
            var prodModel = new List<OrderDetails>();
            foreach(var i in orderdto.OrderDetailsDTOs)
            {
               
                var getpro = (from pi in pro
                              where pi.Id == i.Pid
                              select pi).SingleOrDefault();
                amount += getpro.Price * i.Quantity;
                prodModel.Add(new OrderDetails()
                {
                    Id = i.Id,
                    Pid = i.Pid,
                    Oid = i.Oid,
                    Price = getpro.Price*i.Quantity,
                    Quantity = i.Quantity,
                });
            }
            var order = new Order();
            order.Id= orderdto.Id;
            order.Rid = orderdto.Rid;   
            order.Uid= orderdto.Uid;  
            order.RestaurantName= orderdto.RestaurantName;
            order.lat = orderdto.lat;
            order.lan = orderdto.lan;
            order.Date= DateTime.Now;
            order.OrderStatus = orderdto.OrderStatus;
            order.Amount = amount;
            order.OrderDetails= prodModel;
            var pros = DataAccessFactory.ProductData().Get();
            foreach (var product in order.OrderDetails)
            {

                var onepro = (from i in pros
                              where i.Id == product.Pid
                              select i).SingleOrDefault();
                onepro.Quantity= onepro.Quantity-product.Quantity;
                DataAccessFactory.ProductData().Update(onepro);
            }
            


            return DataAccessFactory.OrderData().Create(order);
        }

        public static bool Update(OrderDTO orderdto)
        {
            var order = new Order();
            order.Id = orderdto.Id;
            order.Rid = orderdto.Rid;
            order.Uid = orderdto.Uid;
            order.RestaurantName = orderdto.RestaurantName;
            order.lat = orderdto.lat;
            order.lan = orderdto.lan;
            order.Date = orderdto.Date;
            order.OrderStatus = orderdto.OrderStatus;
            order.Amount = orderdto.Amount;
          

            return DataAccessFactory.OrderData().Update(order);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderData().Delete(id);
        }


        //search by address
        public static List<OrderDTO> SearchByAdress(float lat, float lan)
        {
            var address = Get();
            var addaddress = (from i in address
                           where i.lat== lat && i.lan== lan
                           select i).ToList();
            return addaddress;

        }

        public static List<OrderDTO> SearchbyOrderStatus(string orderstatus) 
        {   
             var order = Get(); 
             var orderstat = (from item in order where item.OrderStatus == orderstatus select item).ToList(); 
             return orderstat;
        }
        public static List<OrderDTO> SearchbyAmountG500(int amount) 
        { 
            var order = Get(); 
            var orderstat = (from item in order where item.Amount >= 500 select item).ToList();
            return orderstat; 
        }


    }
}
