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
    public class DeliverymanService
    {
        public static List<DeliverymanDTO> Get()
        {
            var deliverymen = DataAccessFactory.DeliverymanData().Get();
            var dtodeliveryman = new List<DeliverymanDTO>();
            foreach (var item in deliverymen)
            {
                var logAdd = new List<DeliveryLogDTO>();
                var deltypeadd = new List<DeliverymanTypeDTO>();
                foreach (var item2 in item.DeliveryLogs)
                {
                    logAdd.Add(new DeliveryLogDTO()
                    {
                        Id = item2.Id,
                        DeliveryId = item2.DeliveryId,
                        Time = item2.Time,
                        Income = item2.Income,
                        flag = item2.flag,
                        OrderId = item2.OrderId
                    });
                   

                }
                
                dtodeliveryman.Add(new DeliverymanDTO()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Rating = item.Rating,
                    Username = item.Username,
                    Password= item.Password,
                    Location = item.Location,
                    DeliveryManStatus = item.DeliveryManStatus,
                    MobileNumber = item.MobileNumber,
                    dtId = item.dtId,
                    DeliveryLogDTOs = logAdd,
                    DeliverymanTypeDTO = new DeliverymanTypeDTO() { ID= item.DeliverymanType.ID, Type = item.DeliverymanType.Type}
                   
                });
            }
            return dtodeliveryman;
        
             
        }

        public static DeliverymanDTO Get(int id)
        {
            var allderiveryman = Get();
            var sd =(from item in allderiveryman
                     where item.ID == id
                     select item).SingleOrDefault();
            return sd;
        }

        public static bool Create(DeliverymanDTO deliverymandto)
        {
            var deliveryman = new Deliveryman();
            deliveryman.ID = deliverymandto.ID;
            deliveryman.Name = deliverymandto.Name; 
            deliveryman.Rating = deliverymandto.Rating;
            deliveryman.Location = deliverymandto.Location;
            deliveryman.DeliveryManStatus= deliverymandto.DeliveryManStatus;
            deliveryman.MobileNumber = deliverymandto.MobileNumber;
            deliveryman.Username= deliverymandto.Username;
            deliveryman.Password= deliverymandto.Password;
            deliveryman.dtId = deliverymandto.dtId;
           
            DataAccessFactory.DeliverymanData().Create(deliveryman);
           
            var getuser = (from i in DataAccessFactory.DeliverymanData().Get()
                           where i.Username == deliverymandto.Username &&
                           i.Password == deliverymandto.Password
                           select i).SingleOrDefault();
            var alluser = new AllUser();
            alluser.UId = getuser.ID;
            alluser.Role = "Deliveryman";
            alluser.Username = deliverymandto.Username;
            alluser.Password = deliverymandto.Password;

            return DataAccessFactory.AllUserData().Create(alluser);

        }

        public static bool Update(DeliverymanDTO deliverymandto)
        {
            var deliveryman = new Deliveryman();
            deliveryman.ID = deliverymandto.ID;
            deliveryman.Name = deliverymandto.Name;
            deliveryman.Rating = deliverymandto.Rating;
            deliveryman.Location = deliverymandto.Location;
            deliveryman.DeliveryManStatus = deliverymandto.DeliveryManStatus;
            deliveryman.MobileNumber = deliverymandto.MobileNumber;
            deliveryman.dtId = deliverymandto.dtId;
            deliveryman.Username = deliverymandto.Username;
            deliveryman.Password = deliverymandto.Password;
            return DataAccessFactory.DeliverymanData().Update(deliveryman);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.DeliverymanData().Delete(id); 
        }

      
    }
}
