using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class DeliverymanType
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Deliveryman> Deliverymens { get; set; }
        public DeliverymanType() {
            Deliverymens = new List<Deliveryman>();
        }
    }
}
