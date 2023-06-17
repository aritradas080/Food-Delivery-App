using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Restaurant")]
        public int Rid { get; set; }
        [ForeignKey("User")]
        public int Uid { get; set; }

        public string RestaurantName { get; set; }

        public float lat { get; set; }
        public float lan { get; set; }

        public DateTime Date { get; set; }

        public string OrderStatus { get; set; }

        public int Amount { get; set; }

        public Restaurant Restaurant { get; set; }
        public User User { get; set; }


        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();

        }
    }
}
