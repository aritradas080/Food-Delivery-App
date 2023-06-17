using Finalv1BLL.ModelDTOs;
using Finalv1DAL;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public class DeliveryLogService
    {
        public static List<DeliveryLogDTO> Get()
        {
            var list1 = DataAccessFactory.DeliveryLogData().Get();
            var list2 = new List<DeliveryLogDTO>();
            foreach (var item in list1)
            {
                var dl = (from i in DataAccessFactory.DeliverymanData().Get()
                          where item.DeliveryId == i.ID
                          select i).SingleOrDefault();
                var delivery = new DeliverymanDTO()
                {
                    ID = dl.ID,
                    Name = dl.Name,
                    Rating = dl.Rating,
                    Location = dl.Location,
                    DeliveryManStatus = dl.DeliveryManStatus,
                    MobileNumber = dl.MobileNumber
                };
                list2.Add(new DeliveryLogDTO()
                {
                    Id = item.Id,
                    DeliveryId = item.DeliveryId,
                    Time = item.Time,
                    Income = item.Income,
                    flag = item.flag,
                    OrderId = item.OrderId,
                    DeliverymanDTO = delivery
                });


            }
            return list2;

        }

        public static bool IDAcceptlog(int DID, int OID)
        {
            var orders = DataAccessFactory.OrderData().Get();
            var order = (from i in orders
                         where i.Id == OID
                         select i).SingleOrDefault();
            order.OrderStatus = "Pending";
            DataAccessFactory.OrderData().Update(order);
            var dman = DataAccessFactory.DeliverymanData().Get();
            var dm = (from i in dman
                      where i.ID == DID
                      select i).SingleOrDefault();
            dm.DeliveryManStatus = "Busy";
            DataAccessFactory.DeliverymanData().Update(dm);
            var dlog = new DeliveryLog();
            dlog.OrderId = OID;
            dlog.DeliveryId = DID;
            dlog.flag = false; return DataAccessFactory.DeliveryLogData().Create(dlog);
        }

        public static bool DeliveredStatus(int lid)
        {
            var deliverylog = DataAccessFactory.DeliveryLogData().Get();
            var dl = (from i in deliverylog
                      where i.Id == lid
                      select i).SingleOrDefault();
            var orders = DataAccessFactory.OrderData().Get();
            var order = DataAccessFactory.OrderData().Get(dl.OrderId);
            dl.flag = true;
            dl.Time = DateTime.Now;
            dl.Income = (float)(order.Amount * 0.10);
            DataAccessFactory.DeliveryLogData().Update(dl);
            var deliverymans = DataAccessFactory.DeliverymanData().Get();
            var deliveryman = DataAccessFactory.DeliverymanData().Get(dl.DeliveryId);
            deliveryman.DeliveryManStatus = "Availabe";
            DataAccessFactory.DeliverymanData().Update(deliveryman);
           
            order.OrderStatus = "Delivered";
            return DataAccessFactory.OrderData().Update(order);

        }
    }

}
