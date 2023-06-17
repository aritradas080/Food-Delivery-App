using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string MobileNumber { get; set; }

        public virtual ICollection<OrderDTO> OrderDTOs { get; set; }
        public virtual ICollection<ChatDto> ChatDtos { get; set; }
        public virtual ICollection<FeedBackDTO> FeedBackDTOs { get; set; }

        public UserDTO()
        {
            OrderDTOs = new List<OrderDTO>();
            ChatDtos= new List<ChatDto>();
            FeedBackDTOs= new List<FeedBackDTO>();
        }
    }
}
