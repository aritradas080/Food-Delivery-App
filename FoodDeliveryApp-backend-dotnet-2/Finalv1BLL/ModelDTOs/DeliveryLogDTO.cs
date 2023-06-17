using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class DeliveryLogDTO
    {
        public int Id { get; set; }
       
        
        [ForeignKey("DeliverymanDTO")]
        public int DeliveryId { get; set; }

        public DateTime? Time { get; set; }
        [Required]
       
        public float Income { get; set; }

        public bool? flag { get; set; }
        [ForeignKey("OrderDTO")]

        public int OrderId { get; set; }

        public virtual DeliverymanDTO DeliverymanDTO { get; set; }
        public virtual OrderDTO OrderDTO { get; set; }

        
    }
}
