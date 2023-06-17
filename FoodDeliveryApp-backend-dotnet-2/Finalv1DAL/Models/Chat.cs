using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    public class Chat
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int Uid { get; set; }
        [ForeignKey("Deliveryman")]
        public int DId { get; set; }
        public String Msg { get; set; }
        public virtual User User{ get; set; }
        public virtual Deliveryman Deliveryman { get; set; }
    }
}
