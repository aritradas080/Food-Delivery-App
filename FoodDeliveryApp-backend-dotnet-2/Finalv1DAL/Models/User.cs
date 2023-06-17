using Finalv1DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        

        public User()
        {
            Orders = new List<Order>();
            Chats= new List<Chat>();
            
        }
    }
}
