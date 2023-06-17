using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Status { get; set; }
        [Required]
       
        public int Rating { get; set; }
        [Required]
        public int Discount { get; set; }

        public virtual ICollection<ProductDTO> ProductDTOs { get; set; }
        public virtual ICollection<OrderDTO> OrderDTOs { get; set; }

        public RestaurantDTO()
        {
            ProductDTOs = new List<ProductDTO>();
            OrderDTOs = new List<OrderDTO>();
        }
    }
}
