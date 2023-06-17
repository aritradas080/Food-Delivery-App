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
    public class DeliverymanTypeService
    {
        public static List<DeliverymanTypeDTO> Get()
        {
            var deltype = DataAccessFactory.DeliverymanTypeData().Get();
            var dtodeltype = new List<DeliverymanTypeDTO>();
            foreach(var item in deltype )
            {
                var deladd = new List<DeliverymanDTO>();
                foreach(var item2 in item.Deliverymens)
                {
                    deladd.Add(new DeliverymanDTO()
                    {
                        ID= item2.ID,
                        Name= item2.Name,
                        Rating= item2.Rating,
                        Username= item2.Username,
                        Password  = item2.Password,
                        Location= item2.Location,
                        DeliveryManStatus= item2.DeliveryManStatus,
                        MobileNumber= item2.MobileNumber,
                        dtId= item2.dtId,
                   


                    });
                }
                dtodeltype.Add(new DeliverymanTypeDTO()
                {
                    ID= item.ID,
                    Type= item.Type,
                    DeliverymensDTO= deladd,

                });

            }
            return dtodeltype;

        }


        public static DeliverymanTypeDTO Get(int id)
        {
            var deliverymanTypes = Get();
            var sd = (from item in deliverymanTypes
                      where item.ID == id
                      select item).SingleOrDefault();
            return sd;
        }

        public static bool Create(DeliverymanTypeDTO deliverymanTypeDTO)
        {
            var deliverymanType = new DeliverymanType();
            deliverymanType.ID = deliverymanTypeDTO.ID;
            deliverymanType.Type= deliverymanTypeDTO.Type;
            return DataAccessFactory.DeliverymanTypeData().Create(deliverymanType);

        }


        public static bool Update(DeliverymanTypeDTO deliverymanTypeDTO)
        {
            var deliverymanType = new DeliverymanType();
            deliverymanType.ID= deliverymanTypeDTO.ID;
            deliverymanType.Type= deliverymanTypeDTO.Type;
            return DataAccessFactory.DeliverymanTypeData().Update(deliverymanType);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.DeliverymanTypeData().Delete(id);
        }











    }
}
