using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int Pid { get; set; }
        [ForeignKey("Order")]
        public int Oid { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
