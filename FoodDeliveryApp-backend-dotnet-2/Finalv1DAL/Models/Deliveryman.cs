using Finalv1DAL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class Deliveryman
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }

        public string Location { get; set; }    

        public string DeliveryManStatus { get; set; }

        public string MobileNumber { get; set; }

        public virtual ICollection<DeliveryLog> DeliveryLogs { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }

        [ForeignKey("DeliverymanType")]

        public int dtId { get; set; }
        public virtual DeliverymanType DeliverymanType { get; set; }

        public Deliveryman()
        {
            DeliveryLogs = new List<DeliveryLog>();
            Chats = new List<Chat>();
            
        }
    }
}
