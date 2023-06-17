using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class DeliveryLog
    {
        public int Id { get; set; }
        [ForeignKey("Deliveryman")]
        public int DeliveryId { get; set; }

        public DateTime? Time { get; set; } 

        public float Income { get; set; }

        public bool? flag { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Deliveryman Deliveryman { get; set; }

        public virtual Order Order { get; set; }    


    }
}
