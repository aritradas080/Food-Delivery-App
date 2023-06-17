using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price_Range { get; set; }
        public string Spice_Level { get; set; }
        public string Time_To_Prep { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Cuisine()
        {
            Products = new List<Product>();
        }
    }
}
