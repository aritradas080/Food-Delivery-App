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
    public class OrderDTO
    {

        public int Id { get; set; }
        [ForeignKey("RestaurantDTO")]
        public int Rid { get; set; }
        [ForeignKey("UserDTO")]
        public int Uid { get; set; }
        [Required]
        [StringLength(100)]
        public string RestaurantName { get; set; }
        [Required]
        public float lat { get; set; }
        [Required]
        public float lan { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(100)]
        public string OrderStatus { get; set; }
        [Required]
        public int Amount { get; set; }

        public RestaurantDTO RestaurantDTO { get; set; }
        public UserDTO UserDTO { get; set; }


        public virtual ICollection<OrderDetailsDTO> OrderDetailsDTOs { get; set; }

        public OrderDTO()
        {
            OrderDetailsDTOs = new List<OrderDetailsDTO>();

        }
    }
}
