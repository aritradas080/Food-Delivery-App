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
    public class OrderDetailsService
    {
        public static List<OrderDetailsDTO> Get()
        {
            var list1 = DataAccessFactory.OrderDetailsData().Get();
            var list2 = new List<OrderDetailsDTO>();
            foreach (var item in list1)
            {
                list2.Add(new OrderDetailsDTO()
                {
                   Id= item.Id,
                   Pid=item.Pid,
                   Oid=item.Oid,
                   Price=item.Price,
                   Quantity=item.Quantity
                });
            }
            return list2;
        }

        public static OrderDetailsDTO Get(int id)
        {
            var allorddet = Get();
            var orddet = (from item in allorddet
                          where item.Id == id
                       select item).SingleOrDefault();
            return orddet;
        }

        public static bool Create(OrderDetailsDTO orderDetailsDTO)
        {
            var orderdetails = new OrderDetails();
            orderdetails.Id = orderDetailsDTO.Id;
            orderdetails.Pid = orderDetailsDTO.Pid;
            orderdetails.Oid = orderDetailsDTO.Oid;
            orderdetails.Price = orderDetailsDTO.Price;
            orderdetails.Quantity= orderDetailsDTO.Quantity;    
            return DataAccessFactory.OrderDetailsData().Create(orderdetails);
        }

        public static bool Update(OrderDetailsDTO orderDetailsDTO) {
            var orderdetails = new OrderDetails();
            orderdetails.Id = orderDetailsDTO.Id;
            orderdetails.Pid = orderDetailsDTO.Pid;
            orderdetails.Oid = orderDetailsDTO.Oid;
            orderdetails.Price = orderDetailsDTO.Price;
            orderdetails.Quantity = orderDetailsDTO.Quantity;
            return DataAccessFactory.OrderDetailsData().Update(orderdetails);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDetailsData().Delete(id);
        }
    }
}
