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
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        [ForeignKey("ProductDTO")]
        public int Pid { get; set; }
        [ForeignKey("OrderDTO")]
        public int Oid { get; set; }
        [Required]
      
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public ProductDTO ProductDTO { get; set; }

        public OrderDTO OrderDTO { get; set; }
    }
}
