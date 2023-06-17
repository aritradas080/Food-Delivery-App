using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
        [ForeignKey("Restaurant")]
        public int Rid { get; set; }

        [ForeignKey("Cuisine")]
        public int Cid { get; set; }

        public Restaurant Restaurant { get; set; }
        public Cuisine Cuisine { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public Product()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
